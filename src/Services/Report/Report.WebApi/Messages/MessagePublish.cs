using Newtonsoft.Json;
using RabbitMQ.Client;
using Report.SharedMessage.RabbitmqInstance;
using Report.WebApi.Models;
using System;
using System.Text;

namespace Report.WebApi.Messages
{
    public static class MessagePublish
    {
        public static async void publish(ReportMessageCommand reportMessage)
        {
            var factory= RabbitService.getInstance();

            var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare("excel-creator", true, false, false);

            var json = JsonConvert.SerializeObject(reportMessage);
            var body = Encoding.UTF8.GetBytes(json);
            channel.BasicPublish(exchange: "ExcelDirectExchange", routingKey: "excel-creator-route", null, body);
        }

    }
}
