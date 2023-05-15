using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = Entities.Concrete.Type;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfTypeDal : EfEntityRepositoryBase<Type, CICRequestContext>, ITypeDal
    {
        public EfTypeDal(CICRequestContext ctex) : base(ctex)
        {

        }
    }
}
