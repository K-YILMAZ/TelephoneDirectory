using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Report.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.WebApi.Messages
{
    public static class Message
    {
        public static async void publish(ReportMessageCommand reportMessage)
        {
            var factory = new ConnectionFactory();

            factory.Uri = new Uri("amqp://localhost");

            var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare("excell-creator", true, false, false);

            var json = JsonConvert.SerializeObject(reportMessage);
            var body = Encoding.UTF8.GetBytes(json);
            channel.BasicPublish(exchange: "", routingKey: "excell-creator", null, body);
        }

        public static async void ReceiveMessageFromQ()
        { 
            var factory = new ConnectionFactory();

            factory.Uri = new Uri("amqp://localhost");

            var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare("excell-creator", true, false, false);
            channel.BasicQos(prefetchSize:0,prefetchCount:3,global:false);

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += async (ReportMessageCommand, ea) =>
              {
                  var body = ea.Body.ToArray();
                  var message = Encoding.UTF8.GetString(body);
                  channel.BasicAck(ea.DeliveryTag, false);
              };
            channel.BasicConsume(queue: "excell-creator", autoAck: false, consumer: consumer);
        }
    }
}
