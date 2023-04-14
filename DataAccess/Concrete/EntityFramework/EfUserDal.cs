using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, CICRequestContext>, IUserDal
    {
        private CICRequestContext _context;
        public EfUserDal(CICRequestContext ctex) : base(ctex)
        {
            _context = ctex;
        }

        public List<OperationClaim> GetClaims(User user)
        {

            var result = from operationClaim in _context.OperationClaims
                         join userOperationClaim in _context.UserOperationClaims
                             on operationClaim.Id equals userOperationClaim.OperationClaim.Id
                         where userOperationClaim.User.Id == user.Id
                         select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
            return result.ToList();


        }


    }
}
