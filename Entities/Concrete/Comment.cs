using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Comment:IEntity
    {
        public int Id { get; set; }
        public string  Text { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public int RequestId { get; set; }

        public User User { get; set; }
        public Request Request { get; set; }
    }
}
