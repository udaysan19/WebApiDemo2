using AutoMapper;
using WebApiDemo2.Data;
using WebApiDemo2.Models;

namespace WebApiDemo2.Helper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Portusers, Portuser>().ReverseMap();
            CreateMap<Portslots, Portslot>().ReverseMap();
        }
    }
}
