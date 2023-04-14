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
        IDataResult<List<RequestDto>> GetAllRequestDto(bool Executepermisson, bool Createpermisson);
        IDataResult<List<RequestDto>> GetAllRequestDtoByCategoryId(short categoryid);
        IResult Add(CreateRequestDto  createRequestDto);
        IQueryable<Request> GetAllRequest();
    }
}
