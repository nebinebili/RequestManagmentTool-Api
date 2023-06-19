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
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class HistoryManager : IHistoryService
    {
        private readonly IUnitofWork _unitofWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HistoryManager(IUnitofWork unitofWork, IMapper mapper,IHttpContextAccessor httpContextAccessor)
        {
            _unitofWork = unitofWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }
        public IDataResult<List<HistoryDto>> GetAllByReqeustId(int requestid)
        {
            int userid = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);

            if (!_unitofWork.Request.GetAllRequest(userid).Any(r => r.Id == requestid))
            {
                return new ErrorDataResult<List<HistoryDto>>(Messages.UserHasNoRequest);
            }

            var histories = _unitofWork.History.GetAll(h => h.RequestId == requestid).Include(h => h.User);

            var historiesDtos = _mapper.Map<List<HistoryDto>>(histories);

            return (historiesDtos.Count!=0) ? new SuccessDataResult<List<HistoryDto>>(historiesDtos, Messages.SuccessfullyListed) :
                                              new SuccessDataResult<List<HistoryDto>>(Messages.NullData);
        }
    }
}
