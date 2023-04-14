using Entities.Abstract;
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
       public string UserName { get; set; }
       public byte[] PasswordSalt { get; set; }
       public byte[] PasswordHash { get; set; }
       public string Department { get; set; }
       public string Position { get; set; }
       public string InnerPhone { get; set; }
       public string MobilPhone { get; set; }
       public string? ProfilPicture { get; set; }
       public bool NotificationPermission { get; set; }
       public bool IsActive { get; set; }
       public DateTime CreatedDate { get; set; }

        public ICollection<Request> SenderRequests { get; set; }
        public ICollection<Request> ExecutorRequests { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<History> Histories { get; set; }
        public ICollection<CategoryUser> CategoryUsers { get; set; }
        public ICollection<UserOperationClaim>  UserOperationClaims { get; set; }
        


    }
}
