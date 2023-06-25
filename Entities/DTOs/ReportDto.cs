using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class ReportDto:IDto
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string StatusName { get; set; }
        public string ExecutorName { get; set; }
        public string SenderName { get; set; }
        public DateTime Date { get; set; }
        public DateTime? FirstExecuteDate { get; set; }
        public DateTime? CloseDate { get; set; }
        public double ExecuteTime { get; set; }
    }
}
