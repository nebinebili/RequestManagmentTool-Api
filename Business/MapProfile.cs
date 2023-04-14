﻿using AutoMapper;
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
                ForMember(dest => dest.ExecutorName, opt => opt.MapFrom(src => src.Executor.UserName)).
                ForMember(dest => dest.SenderName, opt => opt.MapFrom(src => src.Sender.UserName));

            CreateMap<UserRegisterDto,User>().
                ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName)).
                ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName)).
                ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName)).
                ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Department)).
                ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.Position)).
                ForMember(dest => dest.InnerPhone, opt => opt.MapFrom(src => src.InnerPhone)).
                ForMember(dest => dest.MobilPhone, opt => opt.MapFrom(src => src.MobilPhone)).
                ForMember(dest => dest.ProfilPicture, opt => opt.MapFrom(src => src.ProfilPicture));

            CreateMap<CreateRequestDto, Request>().
                ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId)).
                ForMember(dest => dest.RequestTypeId, opt => opt.MapFrom(src => src.RequestTypeId)).
                ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title)).
                ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Text)).
                ForMember(dest => dest.PriorityId, opt => opt.MapFrom(src => src.PriorityId)).ReverseMap();

        }
    }
}
