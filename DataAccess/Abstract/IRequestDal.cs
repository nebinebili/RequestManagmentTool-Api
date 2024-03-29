﻿using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IRequestDal:IEntityRepository<Request>
    {
        public List<Request> GetAllMyRequest(int userId);
        public List<Request> GetAllRequest(int userId);
    }
}
