using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using ReportBackgroundService.Controls;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReportBackgroundService.Services
{
    public class ReportDataCollectorService : BackgroundService
    {
        private IConnection _connection;
        private Task _executingTask;
        private CancellationTokenSource _cts;
        private ConnectionFactory _factory;
        private EventingBasicConsumer _consumer;
        private IModel _channel;

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _factory = new ConnectionFactory();
            _factory.Uri = new Uri("amqp://localhost");

            _cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
            _executingTask = ExecuteAsync(_cts.Token);
            _connection = _factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.QueueDeclare("excell-creator", true, false, false);
            _channel.BasicQos(prefetchSize: 0, prefetchCount: 3, global: false);

            _consumer = new EventingBasicConsumer(_channel);

            return _executingTask.IsCompleted ? _executingTask : Task.CompletedTask;
        }
        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    _consumer.Received += async (ReportMessageCommand, ea) =>
                    {
                        //excelin Oluştuğu ve rapor datasının güncellendiği yer.
                        var body = ea.Body.ToArray();
                        var message = Encoding.UTF8.GetString(body);
                        CreateExcel.DownloadCommaSeperatedFile(ExcellControl.reportData());
                        _channel.BasicAck(ea.DeliveryTag, false);
                    };
                    _channel.BasicConsume(queue: "excell-creator", autoAck: false, consumer: _consumer);

                    await Task.Delay(1000, stoppingToken);
                }
                catch (OperationCanceledException)
                {
                    return;
                }
            }
        }
        public override Task StopAsync(CancellationToken cancellationToken)
        {
            if (_executingTask == null)
            {
                return Task.CompletedTask;
            }
            _cts.Cancel();

            Task.WhenAny(_executingTask, Task.Delay(-1, cancellationToken)).ConfigureAwait(true);

            cancellationToken.ThrowIfCancellationRequested();

            return Task.CompletedTask;
        }
    }
}
