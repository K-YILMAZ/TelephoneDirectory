using Confluent.Kafka;
using Newtonsoft.Json;
using System;

var config = new ProducerConfig { BootstrapServers = "localhost:5001"
};
using var producer = new ProducerBuilder<Null, string>(config).Build();
try
{
    string? state;
    while ((state=Console.ReadLine())!=null)
    {
        var response = producer.ProduceAsync("weather-topic",
          new Message<Null, string> { Value =JsonConvert.SerializeObject(new weather(state,70))});
    }
   
}
catch (ProduceException<Null,string> exc)
{
    Console.WriteLine(exc.Message);
}
public record weather(string state,int Temparature);

