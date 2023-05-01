using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class AddCommentDto:IDto
    {
        public int RequestId { get; set; }

        public string Text { get; set; }
    }
}
