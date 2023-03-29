using AutoMapper;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace WebAPI
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<SuccessDataResult<IQueryable<Request>>, SuccessDataResult<List<RequestDto>>>();
            CreateMap<Request, RequestDto>().
                ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Text)).
                ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title)).
                ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date));
        }
    }
}
