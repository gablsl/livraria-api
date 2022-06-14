using AutoMapper;
using Livraria.Data;
using Livraria.Data.Dtos.Autor;
using Livraria.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Linq;

namespace Livraria.Controllers
{
    [ApiController]
    [Route("/v1/autor")]
    public class AutorController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public AutorController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaAutor([FromBody] CreateAutorDto autorDto)
        {
            Autor autor = _mapper.Map<Autor>(autorDto);

            _context.Autores.Add(autor);
            _context.SaveChanges();
            return CreatedAtAction(nameof(PesquisaAutorPorId), new { id = autor.Id }, autor);
        }

        [HttpGet]
        public IEnumerable PesquisaAutor()
        {
            return _context.Autores;
        }

        [HttpGet("{id}")]
        public IActionResult PesquisaAutorPorId(int id)
        {
            Autor autor = _context.Autores.FirstOrDefault(autor => autor.Id == id);

            if (autor != null)
            {
                ReadAutorDto autorDto = _mapper.Map<ReadAutorDto>(autor);
                return Ok(autorDto);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaAutor([FromBody] UpdateAutorDto autorDto, int id)
        {
            Autor autor = _context.Autores.FirstOrDefault(autor => autor.Id == id);

            if (autor != null)
            {
                _mapper.Map(autorDto, autor);
                _context.SaveChanges();
                return NoContent();
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaAutor(int id)
        {
            Autor autor = _context.Autores.FirstOrDefault(autor => autor.Id == id);

            if (autor != null)
            {
                _context.Autores.Remove(autor);
                _context.SaveChanges();
                return NoContent();
            }
            return NotFound();
        }
    }
}
