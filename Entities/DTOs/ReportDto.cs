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
        public ReportOfRequestDto  ReportOfRequestDto { get; set; }
    }
}
