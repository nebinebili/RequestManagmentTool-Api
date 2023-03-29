using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class RequestDto:IDto
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}
