using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category, CICRequestContext>, ICategoryDal
    {
        private CICRequestContext _context;
        public EfCategoryDal(CICRequestContext ctex) : base(ctex)
        {
            _context = ctex;
        }

        public List<CategoryForUserIdDto> GetCategoryForUserId(int userId)
        {
            var result = from categoryUser in _context.CategoryUsers
                         join category in _context.Categories on categoryUser.CategoryId equals category.Id
                         where categoryUser.UserId==userId
                         select new CategoryForUserIdDto
                         {
                              Id = category.Id,
                              CreatePermisson=categoryUser.CreatePermisson,
                              ExecutePermisson=categoryUser.ExecutePermisson,
                         };
            return result.ToList();

        }
    }
}
