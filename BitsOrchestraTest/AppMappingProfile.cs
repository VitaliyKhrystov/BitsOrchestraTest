using AutoMapper;
using BitsOrchestraTest.Domain.Entities;
using BitsOrchestraTest.Models;
using BitsOrchestraTest.ViewModel;

namespace BitsOrchestraTest
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<Person, PersonViewModel>().ReverseMap();
            CreateMap<Person, PersonModel>().ReverseMap();
            CreateMap<PersonModelCrvReader, Person>();
        }
    }
}
