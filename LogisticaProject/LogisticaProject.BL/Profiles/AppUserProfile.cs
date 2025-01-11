using AutoMapper;
using LogisticaProject.BL.DTOs;
using LogisticaProject.Core.Entities;

namespace LogisticaProject.BL.Profiles
{
	public class AppUserProfile:Profile
	{
        public AppUserProfile()
        {
            CreateMap<AppUserCreateDto, AppUser>();
            CreateMap<AppUserCreateDto, AppUser>().ReverseMap();
        }
    }
}
