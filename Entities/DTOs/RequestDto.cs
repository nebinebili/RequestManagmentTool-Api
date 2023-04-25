using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class RequestDto : IDto
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string CategoryName { get; set; }
        public string StatusName { get; set; }
        public short StatusId { get; set; }
        public string ExecutorName { get; set; }
        public string SenderName { get; set; }
        public DateTime Date { get; set; }

        
    }
}
