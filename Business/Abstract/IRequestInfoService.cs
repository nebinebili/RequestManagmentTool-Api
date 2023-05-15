using Core.Utilities.Results;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRequestInfoService
    {
        IResult Add(RequestInfoDto requestInfoDto);
        IResult GetByRequestId(int requestid);
    }
}
