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
        private List<Request> _requests = new List<Request>();


        public RequestManager(IUnitofWork unitofWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _unitofWork = unitofWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public IResult Add(CreateRequestDto createRequestDto)
        {
            int userid = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);

            if (_unitofWork.CategoryUser.GetAll(c => c.UserId == userid && c.CreatePermisson == true && c.CategoryId == createRequestDto.CategoryId).SingleOrDefault() == null)
            {
                return new ErrorResult(Messages.NotPermissonCategory);
            }
            var request = _mapper.Map<Request>(createRequestDto);
            request.SenderId = userid;

            _unitofWork.Request.Add(request);
            _unitofWork.Complete();
            return new SuccessResult(Messages.SuccessfullyCreated);
        }

        public IDataResult<List<RequestDto>> GetAllRequestByCategoryId(short? categoryid, short? statusid, int pagenumber, int pagesize)
        {
            int id = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);

            if (categoryid == null)
            {
                _requests = (statusid == null) 
                    ? _unitofWork.Request.GetAllRequest(id).Skip((pagenumber - 1) * pagesize).OrderByDescending(r => r.Date).Take(pagesize).ToList()
                    : _unitofWork.Request.GetAllRequest(id).Where(r => r.StatusId == statusid).Skip((pagenumber - 1) * pagesize).OrderByDescending(r => r.Date).Take(pagesize).ToList();

                var data = _mapper.Map<List<RequestDto>>(_requests);

                return new SuccessDataResult<List<RequestDto>>(data, Messages.SuccessfullyListed);
            }
            else
            {
                _requests = (statusid == null)
                    ? _unitofWork.Request.GetAllRequest(id).Where(r => r.CategoryId == categoryid).Skip((pagenumber - 1) * pagesize).OrderByDescending(r => r.Date).Take(pagesize).ToList()
                    : _unitofWork.Request.GetAllRequest(id).Where(r => r.CategoryId == categoryid && r.StatusId == statusid).Skip((pagenumber - 1) * pagesize).OrderByDescending(r => r.Date).Take(pagesize).ToList();

                var data = _mapper.Map<List<RequestDto>>(_requests);

                return new SuccessDataResult<List<RequestDto>>(data, Messages.SuccessfullyListed);
            }
        }

        public IDataResult<List<RequestDto>> GetAllMyRequest(short? statusid, int pagenumber, int pagesize)
        {
            int id = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);


            _requests = (statusid == null)
                ? _unitofWork.Request.GetAllMyRequest(id).Skip((pagenumber - 1) * pagesize).OrderByDescending(r => r.Date).Take(pagesize).ToList()
                : _unitofWork.Request.GetAllMyRequest(id).Where(r => r.StatusId == statusid).Skip((pagenumber - 1) * pagesize).OrderByDescending(r => r.Date).Take(pagesize).ToList();

            var data = _mapper.Map<List<RequestDto>>(_requests);

            return new SuccessDataResult<List<RequestDto>>(data, Messages.SuccessfullyListed);
        }

        public IDataResult<List<RequestCountByStatusDto>> GetRequestsCountByCategoryId(short? categoryid)
        {
            int id = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);

            if (categoryid == null)
            {
                var ReqCountByStatus = _unitofWork.Request.GetAllRequest(id).GroupBy(r => new { r.StatusId, r.Status.Name }).Select(g => new RequestCountByStatusDto
                {
                    Count = g.Count(),
                    Name = g.Key.Name
                }).ToList();

                ReqCountByStatus.Add(new RequestCountByStatusDto { Name = "Hamisi", Count = ReqCountByStatus.Sum(r => r.Count) });

                return new SuccessDataResult<List<RequestCountByStatusDto>>(ReqCountByStatus, Messages.SuccessfullyListed);
            }
            else
            {
                var ReqCountByStatus = _unitofWork.Request.GetAllRequest(id).Where(r => r.CategoryId == categoryid).GroupBy(r => new { r.StatusId, r.Status.Name }).Select(g => new RequestCountByStatusDto
                {
                    Count = g.Count(),
                    Name = g.Key.Name
                }).ToList();

                return new SuccessDataResult<List<RequestCountByStatusDto>>(ReqCountByStatus, Messages.SuccessfullyListed);
            }
        }

        public IDataResult<List<RequestCountByStatusDto>> GetMyRequestsCount()
        {
            int id = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);

            var ReqCountByStatus = _unitofWork.Request.GetAllMyRequest(id).GroupBy(r => new { r.StatusId, r.Status.Name}).Select(g => new RequestCountByStatusDto
            {
                Count = g.Count(),
                Name = g.Key.Name
            }).ToList();

            ReqCountByStatus.Add(new RequestCountByStatusDto { Name="Hamisi",Count= ReqCountByStatus.Sum(r => r.Count) });

            return new SuccessDataResult<List<RequestCountByStatusDto>>(ReqCountByStatus, Messages.SuccessfullyListed);
        }


        public IDataResult<ReportOfRequestDto> GetReportOfRequestDto(int requestid)
        {
            // Daxil olan userin Bu requestId sorgusu var ya yox yoxlamaq

            var request = _unitofWork.Request.GetAll(r => r.Id == requestid)
                 .Include(r => r.Sender)
                 .Include(r => r.Priority)
                 .Include(r=>r.Status)
                 .Include(r => r.RequestType).FirstOrDefault();


            var lastComment = (_unitofWork.Comment.GetAll(c => c.RequestId == requestid).Count()!=0)
                ? _unitofWork.Comment.GetAll(c => c.RequestId == requestid).Include(c => c.User).ToList().Last()
                : null;
            var reportOfRequestDto = _mapper.Map<ReportOfRequestDto>(request);
            var reportOfLastCommentDto = _mapper.Map<CommentDto>(lastComment);
            reportOfRequestDto.LastComment = reportOfLastCommentDto;

            return new SuccessDataResult<ReportOfRequestDto>(reportOfRequestDto, Messages.SuccessfullyListed);
        }
    }
}