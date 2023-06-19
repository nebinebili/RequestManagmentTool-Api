using Entities.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CreateRequestDto:IDto
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public short CategoryId { get; set; }
        public short PriorityId { get; set; }
        public short RequestTypeId { get; set; }
        public IFormFile? File { get; set; }
    }
}
