using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    
    public class Status:IEntity
    {
        public short Id { get; set; }

        public Enum.StatusType type { get; set; }

        public List<Query> Queries { get; set; } = new List<Query>();

    }
}
