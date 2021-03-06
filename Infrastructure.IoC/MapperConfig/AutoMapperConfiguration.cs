﻿using Application.BlogApplication.ViewModel;
using AutoMapper;
using Domain.Blog.Entity;

namespace Infrastructure.Config.MapperConfig
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateConfiguration();
        }

        public void CreateConfiguration()
        {
            CreateMap<BlogInfo, Blog>();
            CreateMap<Blog, BlogInfo>()
               .ForMember(dst => dst.TypeName, opt => opt.MapFrom(data => data.BlogType.TypeName));
        }
    }
}
