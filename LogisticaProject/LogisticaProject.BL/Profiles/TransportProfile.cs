using AutoMapper;
using LogisticaProject.BL.DTOs;
using LogisticaProject.Core.Entities;

namespace LogisticaProject.BL.Profiles
{
    public class TransportProfile:Profile
    {
        public TransportProfile()
        {
            CreateMap<Transport , TransportDto>().ReverseMap();
        }
    }
}
