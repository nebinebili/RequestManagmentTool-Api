using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RequestManager:IRequestService
    {
        private readonly IUnitofWork unitofWork;


        public RequestManager(IUnitofWork unitofWork)
        {
            this.unitofWork = unitofWork;
        }

        public IResult Add(Request request)
        {
            throw new NotImplementedException();
        }

        public IDataResult< IQueryable<Request>> GetAll()
        {
            return new SuccessDataResult< IQueryable<Request>>(unitofWork.Request.GetAll(),Messages.SuccessfullyListed);

        }
    }
}
