﻿using Core.DataAccess.EntityFramework;
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

    }
}
