using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = Entities.Concrete.Type;

namespace DataAccess.Abstract
{
    public interface ITypeDal : IEntityRepository<Type>
    {

    }
}
