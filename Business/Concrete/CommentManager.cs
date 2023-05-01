using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CommentManager:ICommentService
    {
        private readonly IUnitofWork _unitofWork;
        private readonly IMapper _mapper;

        public CommentManager(IUnitofWork unitofWork,IMapper mapper)
        {
            _unitofWork = unitofWork;
            _mapper = mapper;
        }

        public IResult Add(int userId, int requestId, string text)
        {

            IResult result = BusinessRules.Run(CheckWriteCommentPermisson(userId,requestId));

            if (result != null)
            {
                return result;
            }
            Comment comment = new Comment { RequestId=requestId,UserId=userId,Text=text};
            _unitofWork.Comment.Add(comment);
            _unitofWork.Complete();
            return new SuccessResult(Messages.SuccessfullyCreated);
        }

        public IDataResult<List<CommentDto>> GetAll(int requestid)
        {
            var comments = _unitofWork.Comment.GetAll(c => c.RequestId == requestid).Include(C => C.User).ToList();

            var reportOfCommentDtos = _mapper.Map<List<CommentDto>>(comments);

            return new SuccessDataResult<List<CommentDto>>(reportOfCommentDtos, Messages.SuccessfullyListed);
        }


        private IResult CheckWriteCommentPermisson(int userId, int requestId)
        {
            if (!_unitofWork.Request.GetAllRequest(userId).Any(r => r.Id == requestId))
            {
                return new ErrorResult("You have not permisson write comment");
            }
            return new SuccessResult();

        }

    }
}
