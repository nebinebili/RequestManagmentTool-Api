using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Priority:IEntity
    {
        public short Id { get; set; }
        public Enum.PriorityName Name { get; set; }=Enum.PriorityName.Low;

        public List<Query> Queries { get; set; } = new List<Query>();
    }
}
