using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRequestService
    {
        IDataResult<List<RequestDto>> GetAllMyRequest(short? statusid);
        IDataResult<List<RequestDto>> GetAllRequestByCategoryId(short? categoryid, short? statusid);  
        IDataResult<List<RequestCountByStatusDto>> GetMyRequestsCount();
        IDataResult<List<RequestCountByStatusDto>> GetRequestsCountByCategoryId(short? categoryid);
        IDataResult<ReportOfRequestDto> GetReportOfRequestDto(int requestid);
        IResult Add(CreateRequestDto  createRequestDto);
    }
}
