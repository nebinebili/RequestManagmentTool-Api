using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class QueryType:IEntity
    {
        public short Id { get; set; }
        public string Name { get; set; }

        public List<Query> Queries { get; set; } = new List<Query>();
    }
}
