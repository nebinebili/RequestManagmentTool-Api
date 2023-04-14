using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class UserRegisterDto:IDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
        public string Password { get; set; }
        public string InnerPhone { get; set; }
        public string MobilPhone { get; set; }
        public string? ProfilPicture { get; set; }

        public List<RegisterCategoryDto> Categories { get; set; }

        //public DateTime CreatedDate { get; set; }= DateTime.Now;
    }
}
