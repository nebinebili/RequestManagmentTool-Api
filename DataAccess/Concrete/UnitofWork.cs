using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class UnitofWork : IUnitofWork
    {
        private CICRequestContext _context;

        public UnitofWork(CICRequestContext context)
        {
            this._context = context;
            User=new EfUserDal(this._context);
            Request=new EfRequestDal(this._context);
            Category=new EfCategoryDal(this._context);
            CategoryUser=new EfCategoryUserDal(this._context);
            Comment = new EfCommentDal(this._context);
            RequestInfo=new EfRequestInfoDal(this._context);
            Type=new EfTypeDal(this._context);
            Contact=new EfContactDal(this._context);
            RequestType=new EfRequestTypeDal(this._context);
            Priority=new EfPriorityDal(this._context);
            Status=new EfStatusDal(this._context);
            File=new EfFileDal(this._context);
        }

        public IUserDal User { get; private set; }
        public IRequestDal Request { get; private set; }
        public ICategoryDal Category { get; private set; }
        public ICategoryUserDal CategoryUser { get; private set; }
        public ICommentDal Comment { get; private set; }
        public IRequestInfoDal RequestInfo { get; private set; }
        public ITypeDal Type { get; private set; }
        public IContactDal Contact { get; private set; }
        public IRequestTypeDal RequestType { get; private set; }
        public IPriorityDal Priority { get; private set; }
        public IStatusDal Status { get; private set; }
        public IHistoryDal History { get; private set; }
        public IFileDal File { get; private set; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }
    }
}
