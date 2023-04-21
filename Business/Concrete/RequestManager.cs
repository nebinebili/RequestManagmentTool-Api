using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RequestManager : IRequestService
    {
        private readonly IUnitofWork _unitofWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;



        public RequestManager(IUnitofWork unitofWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _unitofWork = unitofWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;

        }

        public IResult Add(CreateRequestDto createRequestDto)
        {
            int userid = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);

            if(_unitofWork.CategoryUser.GetAll(c=>c.UserId==userid && c.CreatePermisson==true && c.CategoryId==createRequestDto.CategoryId).SingleOrDefault() == null)
            {
                return new ErrorResult(Messages.NotPermissonCategory);
            }
            var request = _mapper.Map<Request>(createRequestDto);
            request.SenderId = userid;
            
            _unitofWork.Request.Add(request);
            _unitofWork.Complete();
            return new SuccessResult(Messages.SuccessfullyCreated);
        }

        public IDataResult<List<RequestDto>> GetAllRequestByCategoryId(short categoryid)
        {
            int id = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);


            var requestlist = _unitofWork.Request.GetAllRequest(id).Where(r => r.CategoryId == categoryid).ToList();

            var data = _mapper.Map<List<RequestDto>>(requestlist);

            return new SuccessDataResult<List<RequestDto>>(data, Messages.SuccessfullyListed);
        }

        public IDataResult<List<RequestDto>> GetAllRequestByStatusId(short statusid)
        {
            int id = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);


            var requestlist = _unitofWork.Request.GetAllRequest(id).Where(r => r.StatusId == statusid).ToList();

            var data = _mapper.Map<List<RequestDto>>(requestlist);

            return new SuccessDataResult<List<RequestDto>>(data, Messages.SuccessfullyListed);
        }


        public IDataResult<List<RequestDto>> GetAllExecutableRequest()
        {
            int id = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);


            var requestlist = _unitofWork.Request.GetAllExecutableRequest(id);


            var data = _mapper.Map<List<RequestDto>>(requestlist);

            return new SuccessDataResult<List<RequestDto>>(data, Messages.SuccessfullyListed);
        }

        public IDataResult<List<RequestDto>> GetAllMyRequest()
        {
            int id = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);


            var requestlist = _unitofWork.Request.GetAllMyRequest(id);


            var data = _mapper.Map<List<RequestDto>>(requestlist);

            return new SuccessDataResult<List<RequestDto>>(data, Messages.SuccessfullyListed);
        }

        public IDataResult<List<RequestDto>> GetAllRequest()
        {
            int id = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);


            var requestlist = _unitofWork.Request.GetAllRequest(id);


            var data = _mapper.Map<List<RequestDto>>(requestlist);

            return new SuccessDataResult<List<RequestDto>>(data, Messages.SuccessfullyListed);
        }
    }
}
