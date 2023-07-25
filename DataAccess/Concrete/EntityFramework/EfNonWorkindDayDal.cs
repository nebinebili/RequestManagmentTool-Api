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
    public class EfNonWorkindDayDal : EfEntityRepositoryBase<NonWorkingDay, CICRequestContext>, INonWorkingDayDal
    {
        public EfNonWorkindDayDal(CICRequestContext ctex) : base(ctex)
        {

        }
    }
}
