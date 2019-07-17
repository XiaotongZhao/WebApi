using Application.MenuApplication.MenuViewModels;
using AutoMapper;
using Domain.MenuService.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.IoC.MapperConfig
{
    public class AutoMapperConfiguration : Profile
    {
        public static void ConfigureAndValidate()
        {
            CreateConfiguration();
            Mapper.AssertConfigurationIsValid();
        }

        public static void CreateConfiguration()
        {
            Mapper.Initialize(cfg => 
            {
                cfg.CreateMap<ChildMenu, ChildMenuViewModel>()
                .ForMember(dst => dst.Url, opt => opt.MapFrom(data => data.Url))
                .ForMember(dst => dst.ViewId, opt => opt.MapFrom(data => data.ViewId));

                cfg.CreateMap<Menu, MenuViewModel>()
                .ForMember(dst => dst.ChildMenuViewModel, opt => opt.MapFrom(data => data.childMenus));
            });
        }
    }
}
