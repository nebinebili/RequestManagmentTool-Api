using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Enum
    {
        public enum StatusType { Open, Lock, Reject, Close, Approve, HoldOn }

        public enum PriorityType { Low, Medium, Hard }
    }
}
