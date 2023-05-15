using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RequestInfoManager:IRequestInfoService
    {
        private readonly IUnitofWork _unitofWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RequestInfoManager(IUnitofWork unitofWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _unitofWork = unitofWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public IResult Add(RequestInfoDto requestInfoDto)
        {
            IResult result = BusinessRules.Run(CheckIsAvileable(requestInfoDto));

            if (result != null)
            {
                return result;
            }



            if (!_unitofWork.RequestInfo.GetAll().Any(ri => ri.RequestId == requestInfoDto.RequestId))
            {
                var requestInfo = _mapper.Map<RequestInfo>(requestInfoDto);
                _unitofWork.RequestInfo.Add(requestInfo);
            }
            else 
            {
                var requestInfoDb = _unitofWork.RequestInfo.GetAll(ri => ri.RequestId == requestInfoDto.RequestId).FirstOrDefault();
                var requestInfoUpdated = _mapper.Map(requestInfoDto,requestInfoDb);
                _unitofWork.RequestInfo.Update(requestInfoUpdated);
                
            }


            //////   RequestInfo da gonderdiyim priorityid,requesttypeid ni requestde update edirem
            var request = _unitofWork.Request.GetAll(r => r.Id == requestInfoDto.RequestId).FirstOrDefault();
            request.PriorityId = requestInfoDto.PriorityId;
            request.RequestTypeId = requestInfoDto.RequestTypeId;
            _unitofWork.Request.Update(request);
            ///////

            

            _unitofWork.Complete();
            return new SuccessResult(Messages.SuccessfullyCreated);
        }

        public IResult GetByRequestId(int requestid)
        {
            // id movcud olub olmama

            var requsetInfo = _unitofWork.RequestInfo.GetAll(ri => ri.RequestId == requestid)
                .Include(ri => ri.Contact)
                .Include(ri => ri.Type)
                .Include(ri => ri.Request).ThenInclude(r=>r.RequestType)
                .Include(ri => ri.Request).ThenInclude(r=>r.Priority)
                
                .FirstOrDefault();

            var requestInfoDto = _mapper.Map<RespRequestInfoDto>(requsetInfo);

            return new SuccessDataResult<RespRequestInfoDto>(requestInfoDto, Messages.SuccessfullyFound);
        }

        private IResult CheckIsAvileable(RequestInfoDto requestInfoDto)
        {
           return 
           (!_unitofWork.Type.GetAll().Any(t => t.Id == requestInfoDto.TypeId)
           ? new ErrorResult("The Type with this id does not exist") :
           (!_unitofWork.Contact.GetAll().Any(c => c.Id == requestInfoDto.ContactId)
           ? new ErrorResult("The Contact with this id does not exist") :
           (!_unitofWork.RequestType.GetAll().Any(rt => rt.Id == requestInfoDto.RequestTypeId)
           ? new ErrorResult("The RequestType with this id does not exist"):
           (!_unitofWork.Priority.GetAll().Any(p => p.Id == requestInfoDto.PriorityId)
           ? new ErrorResult("The Priority with this id does not exist"):
           new SuccessResult()))));
 
        }
    }
}
