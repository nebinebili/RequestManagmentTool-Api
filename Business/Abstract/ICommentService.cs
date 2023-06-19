using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICommentService
    {
        IResult Add(AddCommentDto commentDto);

        IDataResult<List<CommentDto>> GetAllByRequestid(int requestid);
        IResult AddFileToComment(AddFileToCommentDto addFileToCommentDto);
    }
}
