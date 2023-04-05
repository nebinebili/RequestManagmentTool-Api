using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
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
        private readonly IMapper _mapper;


        public RequestManager(IUnitofWork unitofWork, IMapper mapper)
        {
            this.unitofWork = unitofWork;
            _mapper = mapper;
        }

        public IResult Add(Request request)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<RequestDto>> GetAllRequestDto()
        {
            
            var data = _mapper.Map<List<RequestDto>>(GetAllRequest());
            return new SuccessDataResult<List<RequestDto>>(data, Messages.SuccessfullyListed);
        }

        public IDataResult<List<RequestDto>> GetAllRequestDtoByCategoryId(short categoryid)
        {

            var data = GetAllRequest().Where(r => r.CategoryId == categoryid);
            return new SuccessDataResult<List<RequestDto>>(_mapper.Map<List<RequestDto>>(data));
        }

        public IQueryable<Request> GetAllRequest()
        {
            var data = (unitofWork.Request.GetAll()
                .Include(r => r.Category)
                .Include(s => s.Status)
                .Include(e => e.Executor)
                .Include(s => s.Sender));
            return  data;
        }
    }
}
