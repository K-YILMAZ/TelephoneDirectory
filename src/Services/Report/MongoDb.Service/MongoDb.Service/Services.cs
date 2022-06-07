using MongoDB.Driver;
using ReportBackgroundService.Models;
using System;

namespace MongoDb.Service
{
    public  class Services
    {
        public  ReportMessageCommand ServiceAdd()
        {
            var client = new MongoClient("http://localhost:8081");
            var database = client.GetDatabase("Repor");
            var collec = database.GetCollection<ReportMessageCommand>("log");
            var doc = new ReportMessageCommand
            {
                reportStatus = 0,
                requestDate = DateTime.Now,
                uuid = Guid.NewGuid()
            };
            collec.InsertOneAsync(doc);
            Console.Read();
            return doc;
        }
        public static ReportMessageCommand ServiceUpdate (ReportMessageCommand reportMessageCommand)
        {
            var client = new MongoClient("http://localhost:8081");
            var database = client.GetDatabase("Repor");
            var collec = database.GetCollection<ReportMessageCommand>("log");
            var doc = new ReportMessageCommand
            {
                reportStatus = 0,
                requestDate = DateTime.Now,
                uuid = Guid.NewGuid()
            };
            reportMessageCommand.reportStatus = reportStatus.Completed;
            collec.UpdateOneAsync(reportMessageCommand.uuid);
);
            Console.Read();
            return doc;
        }
    }
}
