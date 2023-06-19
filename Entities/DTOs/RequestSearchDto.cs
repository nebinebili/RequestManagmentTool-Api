using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class RequestSearchDto : IDto
    {
        [DefaultValue(null)]
        public short? statusId { get; set; }
        public int pageNumber { get; set; }
        public int pageSize { get; set; }

        [DefaultValue(null)]
        public string? senderName { get; set; }
        [DefaultValue(null)]
        public string? executorName { get; set; }
        [DefaultValue(null)]
        public string? date { get; set; }
        [DefaultValue(null)]
        public string? requestId { get; set; }
        [DefaultValue(null)]
        public string? status { get; set; }
        [DefaultValue(null)]
        public string? title { get; set; }
        [DefaultValue(null)]
        public string? text { get; set; }
        [DefaultValue(null)]
        public string? categoryName { get; set; }
    }
}
