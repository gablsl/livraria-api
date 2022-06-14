using AutoMapper;
using Livraria.Data.Dtos.Autor;
using Livraria.Models;

namespace Livraria.Profiles
{
    public class AutorProfile : Profile
    {
        public AutorProfile()
        {
            CreateMap<CreateAutorDto, Autor>();
            CreateMap<Autor, ReadAutorDto>();
            CreateMap<UpdateAutorDto, Autor>();
        }
    }
}
