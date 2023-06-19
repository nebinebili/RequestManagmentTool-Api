using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using File = Entities.Concrete.File;

namespace Business.Concrete
{
    public class CommentManager : ICommentService
    {
        private readonly IUnitofWork _unitofWork;
        private readonly IMapper _mapper;
        private readonly IFileHelper _fileHelper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IConfiguration _configuration { get; }
        public CommentManager(IUnitofWork unitofWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, IFileHelper fileHelper, IConfiguration configuration)
        {
            _unitofWork = unitofWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _fileHelper = fileHelper;
            _configuration = configuration;
        }

        public IResult Add(AddCommentDto commentDto)
        {
            int userid = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            IResult result = BusinessRules.Run(CheckWriteCommentPermisson(userid, commentDto.RequestId));

            if (result != null)
            {
                return result;
            }
            File commentFile = new File();
            if (commentDto.File != null)
            {
                string str = _configuration.GetSection("FilePaths").GetSection("CommentFilepath").Value;
                var filePath = _fileHelper.Upload(commentDto.File, str);

                commentFile.FileOriginalName = commentDto.File.FileName;
                commentFile.Size = commentDto.File.Length;
                commentFile.MimeType = commentDto.File.ContentType;
                commentFile.Extension = Path.GetExtension(filePath);
                commentFile.FileName = filePath;
                commentFile.Path = str;



                _unitofWork.File.Add(commentFile);
            }


            Comment newcomment = new Comment { RequestId = commentDto.RequestId, UserId = userid, Text = commentDto.Text, CFileId = commentFile.Id };
            _unitofWork.Comment.Add(newcomment);


            return new SuccessResult(Messages.SuccessfullyCreated);
        }

        public IDataResult<List<CommentDto>> GetAllByRequestid(int requestid)
        {
            int userid = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);

            if (!_unitofWork.Request.GetAllRequest(userid).Any(r => r.Id == requestid))
            {
                return new ErrorDataResult<List<CommentDto>>(Messages.UserHasNoRequest);
            }

            var comments = _unitofWork.Comment.GetAll(c => c.RequestId == requestid).Include(C => C.User).ToList();

            var reportOfCommentDtos = _mapper.Map<List<CommentDto>>(comments);

            return (reportOfCommentDtos.Count != 0) ? new SuccessDataResult<List<CommentDto>>(reportOfCommentDtos, Messages.SuccessfullyListed) :
                                              new SuccessDataResult<List<CommentDto>>(Messages.NullData);
        }


        private IResult CheckWriteCommentPermisson(int userId, int requestId)
        {
            if (!_unitofWork.Request.GetAllRequest(userId).Any(r => r.Id == requestId))
            {
                return new ErrorResult("You have not permisson write comment");
            }
            return new SuccessResult();

        }

        public IResult AddFileToComment(AddFileToCommentDto addFileToCommentDto)
        {
            int userid = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            IResult result = BusinessRules.Run(CheckWriteCommentPermisson(userid, addFileToCommentDto.RequestId));

            if (result != null)
            {
                return result;
            }

            var comment = _unitofWork.Comment.GetAll(c => c.RequestId == addFileToCommentDto.RequestId).SingleOrDefault();



            string str = _configuration.GetSection("FilePaths").GetSection("CommentFilepath").Value;
            string filePath;


            if (comment.CFileId == null)
            {
                filePath = _fileHelper.Upload(addFileToCommentDto.File, str);
            }
            else
            {
                var currentFile = _unitofWork.File.GetAll(f => f.Id == comment.CFileId).SingleOrDefault();
                filePath = _fileHelper.Update(addFileToCommentDto.File, currentFile.Path + "\\" + currentFile.FileName, str);
            }


            File commentFile = new File
            {
                FileOriginalName = addFileToCommentDto.File.FileName,
                Size = addFileToCommentDto.File.Length,
                MimeType = addFileToCommentDto.File.ContentType,
                Extension = Path.GetExtension(filePath),
                FileName = filePath,
                Path = str
            };

            if (comment.CFileId != null) _unitofWork.File.Delete(_unitofWork.File.GetAll(f => f.Id == comment.CFileId).SingleOrDefault());
            _unitofWork.File.Add(commentFile);

            comment.CFileId = commentFile.Id;
            _unitofWork.Comment.Update(comment);

            return new SuccessResult(Messages.SuccessfullyUpdated);
        }
    }
}
