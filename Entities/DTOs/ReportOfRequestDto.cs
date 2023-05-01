using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class ReportOfRequestDto:IDto
    {
        public string UserFullName { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
        public string RequestType { get; set; }
        public string Priority { get; set; }
        public string Text { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
        public CommentDto LastComment { get; set; }

    }
}
