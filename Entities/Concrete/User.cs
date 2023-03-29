using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class User:IEntity
    {
       public int Id { get; set; }
       public string FirstName { get; set; }
       public string LastName { get; set; }
       public string Password { get; set; }
       public string Department { get; set; }
       public string Position { get; set; }
       public string InnerPhone { get; set; }
       public string MobilPhone { get; set; }
       public string? ProfilPicture { get; set; }
       public bool NotificationPermission { get; set; }
       public bool IsActive { get; set; }
       public DateTime CreatedDate { get; set; }

        public ICollection<Request> SenderRequests { get; set; }
        public ICollection<Request> CreatorRequests { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<History> Histories { get; set; }


    }
}
