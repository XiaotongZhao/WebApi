using AutoMapper;
using Application.MenuApplication.MenuViewModels;
using Domain.MenuService.Entity;

namespace Infrastructure.IoC.MapperConfig
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateConfiguration();
        }

        public void CreateConfiguration()
        {
            CreateMap<ChildMenu, ChildMenuViewModel>()
                .ForMember(dst => dst.Url, opt => opt.MapFrom(data => data.Url))
                .ForMember(dst => dst.ViewId, opt => opt.MapFrom(data => data.ViewId));

            CreateMap<Menu, MenuViewModel>()
                .ForMember(dst => dst.ChildMenuViewModel, opt => opt.MapFrom(data => data.childMenus));
        }
    }
}
