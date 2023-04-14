using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
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
        private readonly IUnitofWork _unitofWork;

        public UserManager(IUnitofWork unitofWork)
        {
           _unitofWork = unitofWork;
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _unitofWork.User.GetClaims(user);
        }

        public User GetByUserName(string username)
        {
            return _unitofWork.User.Get(u=>u.UserName==username);
        }

        public void Add(User user)
        {
            _unitofWork.User.Add(user);
            _unitofWork.Complete();
        }
    }
}
