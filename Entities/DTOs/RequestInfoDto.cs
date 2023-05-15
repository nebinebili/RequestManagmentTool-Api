using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class RequestInfoDto:IDto
    {
        public string? Result { get; set; }
        public string? Solution { get; set; }
        public double? ExecutionTime { get; set; }
        public double? PlannedExecutionTime { get; set; }
        public short? TypeId { get; set; }
        public string? RequestSender { get; set; }
        public string? SolmanRequestNumber { get; set; }
        public short? ContactId { get; set; }
        public bool? Rountine { get; set; }
        public string? Code { get; set; }
        public string? RootCause { get; set; }
        public int? RequestId { get; set; }
        public short PriorityId { get; set; }
        public short RequestTypeId { get; set; }
    }
}
