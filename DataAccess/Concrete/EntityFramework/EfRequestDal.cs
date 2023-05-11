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
    public class EfRequestDal: EfEntityRepositoryBase<Request, CICRequestContext>, IRequestDal
    {
        private CICRequestContext _context;
        public EfRequestDal(CICRequestContext ctex) : base(ctex)
        {
            _context = ctex;
        }

        public List<Request> GetAllMyRequest(int userId)
        {
            var result = from r in _context.Requests
                         join cu in _context.CategoryUsers on r.CategoryId equals cu.CategoryId
                         where (cu.CreatePermisson == true && r.SenderId == userId)   && cu.UserId == userId || 
                               (cu.ExecutePermisson==true  && r.ExecutorId == userId) && cu.UserId == userId
                         select r;
            
            return result
                .Include(r => r.Category)
                .Include(r => r.Status)
                .Include(r => r.Executor)
                .Include(r => r.Sender).ToList();
        }

        public List<Request> GetAllRequest(int userId)
        {
            var result = from r in _context.Requests
                         join cu in _context.CategoryUsers on r.CategoryId equals cu.CategoryId
                         where cu.ExecutePermisson == true && cu.UserId == userId && r.SenderId != userId ||
                               cu.CreatePermisson == true && cu.UserId == userId && r.SenderId == userId
                         select r;
            return result 
                .Include(r => r.Category)
                .Include(r => r.Status)
                .Include(r => r.Executor)
                .Include(r => r.Sender).ToList();
        }
    }
}
