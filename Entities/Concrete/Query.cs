using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Query:IEntity
    {
        public int Id { get; set; }
        public string Sender { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Executor { get; set; }
        public DateTime Date { get; set; }

        public int CategoryId { get; set; }
        public int StatusId { get; set; }
        public int PriorityId { get; set; }
        public int QueryTypeId { get; set; }

        public Category Category { get; set; }
        public Status Status { get; set; }
        public Priority Priority { get; set; }
        public QueryType QueryType { get; set; }

    }
}
