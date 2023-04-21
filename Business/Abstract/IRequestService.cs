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
        IDataResult<List<RequestDto>> GetAllExecutableRequest();
        IDataResult<List<RequestDto>> GetAllMyRequest();
        IDataResult<List<RequestDto>> GetAllRequest();
        IDataResult<List<RequestDto>> GetAllRequestByCategoryId(short categoryid);
        IDataResult<List<RequestDto>> GetAllRequestByStatusId(short statusid);     
        IResult Add(CreateRequestDto  createRequestDto);
    }
}
