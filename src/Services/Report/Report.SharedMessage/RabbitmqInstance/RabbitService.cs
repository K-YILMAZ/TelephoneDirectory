
using RabbitMQ.Client;
using System;

namespace Report.SharedMessage.RabbitmqInstance
{
    public class RabbitService
    {
        public static RabbitService _RabbitService;
        public static ConnectionFactory _factory;
        public static ConnectionFactory getInstance()
        {
            if (_RabbitService==null)
            {
                _factory = new ConnectionFactory();
                _factory.Uri = new Uri("amqp://localhost");
                _RabbitService = new RabbitService();
            }
            return _factory;
        }
    }
}
