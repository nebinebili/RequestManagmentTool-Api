using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Type : IEntity
    {
        public short Id { get; set; }
        public string Name { get; set; }

        public ICollection<RequestInfo> RequestInfos { get; set; }
    }
}
