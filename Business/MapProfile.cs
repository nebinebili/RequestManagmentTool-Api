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
            CreateMap<Request, RequestDto>().
                ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Text)).
                ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title)).
                ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date)).
                ForMember(dest => dest.StatusName, opt => opt.MapFrom(src => src.Status.Name)).
                ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name)).
                ForMember(dest => dest.ExecutorName, opt => opt.MapFrom(src => src.Executor.FirstName + " " + src.Executor.LastName)).
                ForMember(dest => dest.SenderName, opt => opt.MapFrom(src => src.Sender.FirstName + " " + src.Sender.LastName));
        }
    }
}
