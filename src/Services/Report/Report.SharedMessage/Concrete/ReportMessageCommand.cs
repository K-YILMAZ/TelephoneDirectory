using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Report.SharedMessage.Concrete
{
    public class ReportMessageCommand
    {
        public Guid uuid { get; set; }
        public DateTime requestDate { get; set; }
        public Guid reportStatus { get; set; }
    }
}
