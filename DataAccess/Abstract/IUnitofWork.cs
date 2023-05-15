using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUnitofWork:IDisposable
    {
        IUserDal User { get; }
        IRequestDal Request { get; }
        ICategoryDal Category { get; }
        ICategoryUserDal CategoryUser { get; }
        ICommentDal Comment { get; }
        IRequestInfoDal RequestInfo { get; }
        ITypeDal Type { get; }
        IContactDal Contact { get; }
        IRequestTypeDal RequestType { get; }
        IPriorityDal Priority { get; }
        int Complete();
    }
}
