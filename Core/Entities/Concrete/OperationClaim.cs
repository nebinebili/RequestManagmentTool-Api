using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class OperationClaim : IEntity
    {
        public short Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }
    }
}
