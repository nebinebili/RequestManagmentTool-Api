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

        public IDataResult<List<RequestDto>> GetAllRequestDto(bool Executepermisson, bool Createpermisson)
        {
            int id = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            var categorylist = _unitofWork.Category.GetCategoryForUserId(id);

            // categori id e gore requestler mueyyen edilir
            List<Request> requestlist = new List<Request>();
            foreach (var category in categorylist)
            {
                if (Executepermisson) requestlist.Add(GetAllRequest().Where(r => r.CategoryId == category.Id && category.ExecutePermisson == Executepermisson).SingleOrDefault());
                if (Createpermisson) requestlist.Add(GetAllRequest().Where(r => r.CategoryId == category.Id && category.CreatePermisson == Createpermisson).SingleOrDefault());
            }
            requestlist.RemoveAll(item => item == null);
            var data = _mapper.Map<List<RequestDto>>(requestlist);

            return new SuccessDataResult<List<RequestDto>>(data, Messages.SuccessfullyListed);
        }

        public IDataResult<List<RequestDto>> GetAllRequestDtoByCategoryId(short categoryid)
        {
            int id = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            var categorylist = _unitofWork.Category.GetCategoryForUserId(id);

            List<Request> requestlist = new List<Request>();
            foreach (var category in categorylist)
            {
                requestlist.Add(GetAllRequest().Where(r => r.CategoryId == category.Id && category.Id == categoryid && category.ExecutePermisson == true).SingleOrDefault());
            }
            requestlist.RemoveAll(item => item == null);
            var data = _mapper.Map<List<RequestDto>>(requestlist);

            return new SuccessDataResult<List<RequestDto>>(data, Messages.SuccessfullyListed);
        }

        public IQueryable<Request> GetAllRequest()
        {
            var data = (_unitofWork.Request.GetAll()
                .Include(r => r.Category)
                .Include(s => s.Status)
                .Include(e => e.Executor)
                .Include(s => s.Sender));
            return data;
        }
    }
}
