using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Request:IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }=DateTime.Now;

        
        public short CategoryId { get; set; }
        public short StatusId { get; set; }
        public short PriorityId { get; set; }
        public short RequestTypeId { get; set; }
        public int SenderId { get; set; }
        public int? ExecutorId { get; set; }
        public int? RequestInfoId { get; set; }

        public Category Category { get; set; }
        public Status Status { get; set; }
        public Priority Priority { get; set; }
        public RequestType RequestType { get; set; }
        public User Executor { get; set; }
        public User Sender { get; set; }
        public RequestInfo? RequestInfo { get; set; }

        public ICollection<Comment> Comments { get; set; }

    }
}
