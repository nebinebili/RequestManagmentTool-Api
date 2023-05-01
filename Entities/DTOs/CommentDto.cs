using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CommentDto:IDto
    {
        public string UserFullName { get; set; }

        public string Position { get; set; }

        public DateTime Date { get; set; }

        public string Text { get; set; }
    }
}
