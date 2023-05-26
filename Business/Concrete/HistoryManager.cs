using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class HistoryManager : IHistoryService
    {
        private readonly IUnitofWork _unitofWork;
        private readonly IMapper _mapper;

        public HistoryManager(IUnitofWork unitofWork, IMapper mapper)
        {
            _unitofWork = unitofWork;
            _mapper = mapper;
        }
        public IDataResult<List<HistoryDto>> GetAllByReqeustId(int requestid)
        {
            var histories = _unitofWork.History.GetAll(h => h.RequestId == requestid).Include(h => h.User);

            var historiesDtos = _mapper.Map<List<HistoryDto>>(histories);

            return new SuccessDataResult<List<HistoryDto>>(historiesDtos, Messages.SuccessfullyListed);
        }
    }
}
