using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Report.SharedMessage.RabbitmqInstance;
using ReportBackgroundService.Controls;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReportBackgroundService.MessageConsumer
{
    public class Consumer : BackgroundService
    {
        private IConnection _connection;
        private Task _executingTask;
        private CancellationTokenSource _cts;
        private ConnectionFactory _factory;
        private EventingBasicConsumer _consumer;
        private IModel _channel;
        

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _factory = RabbitService.getInstance();

            _cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
            _connection = _factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.QueueDeclare("excel-creator", true, false, false);
            _channel.BasicQos(prefetchSize: 0, prefetchCount: 3, global: false);

            _consumer = new EventingBasicConsumer(_channel);

            return base.StartAsync(cancellationToken);
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
                    _channel.BasicConsume(queue: "excel-creator", autoAck: false, consumer: _consumer);

                    await Task.Delay(1000, stoppingToken);

                }
                catch (OperationCanceledException)
                {
                    return;
                }
            }
        }

    }
}
