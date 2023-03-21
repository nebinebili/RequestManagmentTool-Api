using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUnitofWork unitofWork;

        public UserManager(IUnitofWork unitofWork)
        {
           this.unitofWork = unitofWork;
        }

        public User GetByFullName(string fullname)
        {
            return unitofWork.User.Get(u => (u.FirstName + ' ' + u.LastName) == fullname);
        }
    }
}
