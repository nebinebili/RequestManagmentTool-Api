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
        int Complete();
    }
}
