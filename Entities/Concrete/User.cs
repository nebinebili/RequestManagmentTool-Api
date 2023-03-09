using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class User
    {
       public int Id { get; set; }
       public string FirstName { get; set; }
       public string LastName { get; set; }
       public string Password { get; set; }
       public string Department { get; set; }
       public string Position { get; set; }
       public string InnerPhone { get; set; }
       public string MobilPhone { get; set; }

    }
}
