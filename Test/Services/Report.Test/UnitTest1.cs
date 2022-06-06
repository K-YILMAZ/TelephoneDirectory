using Microsoft.VisualStudio.TestTools.UnitTesting;
using Report.WebApi.Messages;
using Report.WebApi.Models;
using System;

namespace Report.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public ReportMessageCommand TestMethod1()
        {
            ReportMessageCommand reportMessage = new ReportMessageCommand
            {
                reportStatus = reportStatus.Preparing,
                requestDate = DateTime.Now,
                uuid = Guid.NewGuid()
            };
            Message.publish(reportMessage);
            return reportMessage;
        }
    }
}
