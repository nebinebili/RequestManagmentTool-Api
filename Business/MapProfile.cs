using AutoMapper;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<SuccessDataResult<IQueryable<Request>>, SuccessDataResult<List<RequestDto>>>();
            CreateMap<SuccessDataResult<List<Comment>>, SuccessDataResult<List<CommentDto>>>();
            CreateMap<Request, RequestDto>().
                ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Text)).
                ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title)).
                ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date)).
                ForMember(dest => dest.StatusName, opt => opt.MapFrom(src => src.Status.Name)).
                ForMember(dest => dest.StatusId, opt => opt.MapFrom(src => src.Status.Id)).
                ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name)).
                ForMember(dest => dest.ExecutorName, opt => opt.MapFrom(src => src.Executor.UserName)).
                ForMember(dest => dest.SenderName, opt => opt.MapFrom(src => src.Sender.UserName));

            CreateMap<UserRegisterDto, User>().
                ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName)).
                ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName)).
                ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName)).
                ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Department)).
                ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.Position)).
                ForMember(dest => dest.InnerPhone, opt => opt.MapFrom(src => src.InnerPhone)).
                ForMember(dest => dest.MobilPhone, opt => opt.MapFrom(src => src.MobilPhone));
           

            CreateMap<CreateRequestDto, Request>().
                ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId)).
                ForMember(dest => dest.RequestTypeId, opt => opt.MapFrom(src => src.RequestTypeId)).
                ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title)).
                ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Text)).
                ForMember(dest => dest.PriorityId, opt => opt.MapFrom(src => src.PriorityId)).ReverseMap();


            CreateMap<Request, ReportOfRequestDto>().
                ForMember(dest => dest.UserFullName, opt => opt.MapFrom(src => src.Sender.FirstName + " " + src.Sender.LastName)).
                ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Sender.Department)).
                ForMember(dest => dest.RequestType, opt => opt.MapFrom(src => src.RequestType.Name)).
                ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Text)).
                ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.Sender.Position)).
                ForMember(dest => dest.Priority, opt => opt.MapFrom(src => src.Priority.Name)).
                ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.Name)).
                ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date));

            CreateMap<Comment, CommentDto>().
                ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Text)).
                ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date)).
                ForMember(dest => dest.UserFullName, opt => opt.MapFrom(src => src.User.FirstName + " " + src.User.LastName)).
                ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.User.Position));

            CreateMap<History, HistoryDto>().
                ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date)).
                ForMember(dest => dest.Message, opt => opt.MapFrom(src => src.Message)).
                ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.User.Position)).
                ForMember(dest => dest.UserFullName, opt => opt.MapFrom(src => src.User.FirstName + " " + src.User.LastName));

            CreateMap<RequestInfoDto, RequestInfo>().
                ForMember(dest => dest.RootCause, opt => opt.MapFrom(src => src.RootCause)).
                ForMember(dest => dest.Result, opt => opt.MapFrom(src => src.Result)).
                ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code)).
                ForMember(dest => dest.ExecutionTime, opt => opt.MapFrom(src => src.ExecutionTime)).
                ForMember(dest => dest.SolmanRequestNumber, opt => opt.MapFrom(src => src.SolmanRequestNumber)).
                ForMember(dest => dest.PlannedExecutionTime, opt => opt.MapFrom(src => src.PlannedExecutionTime)).
                ForMember(dest => dest.Rountine, opt => opt.MapFrom(src => src.Rountine)).
                ForMember(dest => dest.Solution, opt => opt.MapFrom(src => src.Solution)).
                ForMember(dest => dest.RequestSender, opt => opt.MapFrom(src => src.RequestSender)).
                ForMember(dest => dest.ContactId, opt => opt.MapFrom(src => src.ContactId)).
                ForMember(dest => dest.TypeId, opt => opt.MapFrom(src => src.TypeId)).
                ForMember(dest => dest.RequestId, opt => opt.MapFrom(src => src.RequestId));

            CreateMap<RequestInfo, RespRequestInfoDto>().
                ForMember(dest => dest.RootCause, opt => opt.MapFrom(src => src.RootCause)).
                ForMember(dest => dest.Result, opt => opt.MapFrom(src => src.Result)).
                ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code)).
                ForMember(dest => dest.ExecutionTime, opt => opt.MapFrom(src => src.ExecutionTime)).
                ForMember(dest => dest.SolmanRequestNumber, opt => opt.MapFrom(src => src.SolmanRequestNumber)).
                ForMember(dest => dest.PlannedExecutionTime, opt => opt.MapFrom(src => src.PlannedExecutionTime)).
                ForMember(dest => dest.Rountine, opt => opt.MapFrom(src => src.Rountine)).
                ForMember(dest => dest.Solution, opt => opt.MapFrom(src => src.Solution)).
                ForMember(dest => dest.RequestSender, opt => opt.MapFrom(src => src.RequestSender)).
                ForMember(dest => dest.ContactName, opt => opt.MapFrom(src => src.Contact.Name)).
                ForMember(dest => dest.PriorityName, opt => opt.MapFrom(src => src.Request.Priority.Name)).
                ForMember(dest => dest.TypeName, opt => opt.MapFrom(src => src.Type.Name)).
                ForMember(dest => dest.RequestTypeName, opt => opt.MapFrom(src => src.Request.RequestType.Name));
                

        }
    }
}
