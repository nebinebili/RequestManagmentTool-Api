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
        IDataResult<List<RequestDto>> GetAllRequestDto();
        IDataResult<List<RequestDto>> GetAllRequestDtoByCategoryId(short categoryid);
        IResult Add(Request request);
        IQueryable<Request> GetAllRequest();
    }
}
