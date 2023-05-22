using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class History:IEntity
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string Message { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int RequestId { get; set; }
        public Request Request { get; set; }
    }
}
