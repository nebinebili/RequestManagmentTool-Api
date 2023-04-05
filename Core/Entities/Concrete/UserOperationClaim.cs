using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class UserOperationClaim : IEntity
    {
        public short Id { get; set; }
        public short UserId { get; set; }
        public short OperationClaimId { get; set; }
    }
}
