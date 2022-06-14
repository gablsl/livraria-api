using AutoMapper;
using Livraria.Data.Dtos;
using Livraria.Data.Dtos.Livro;
using Livraria.Models;

namespace Livraria.Profiles
{
    public class LivroProfile : Profile
    {
        public LivroProfile()
        {
            CreateMap<CreateLivroDto, Livro>();
            CreateMap<Livro, ReadLivroDto>();
            CreateMap<UpdateLivroDto, Livro>();
        }
    }
}
