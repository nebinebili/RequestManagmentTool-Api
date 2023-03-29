using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    
    public class Status:IEntity
    {
        public short Id { get; set; }

        [MaxLength(20)]
        public string Name { get; set; }

        public List<Request> Requests { get; set; } = new List<Request>();

    }
}
