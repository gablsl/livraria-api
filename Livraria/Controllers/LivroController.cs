using AutoMapper;
using Livraria.Data;
using Livraria.Data.Dtos;
using Livraria.Data.Dtos.Livro;
using Livraria.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Livraria.Controllers
{
    [ApiController]
    [Route("/v1/livro")]
    public class LivroController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public LivroController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaLivro([FromBody] CreateLivroDto livroDto)
        {
            Livro livro = _mapper.Map<Livro>(livroDto); 

            _context.Livros.Add(livro);
            _context.SaveChanges();
            return CreatedAtAction(nameof(PesquisaLivroPorId), new { id = livro.Id }, livro);
        }

        [HttpGet]
        public IEnumerable<Livro> PesquisaLivro()
        {
            return _context.Livros;
        }

        [HttpGet("{id}")]
        public IActionResult PesquisaLivroPorId(int id)
        {
            Livro livro = _context.Livros.FirstOrDefault(livro => livro.Id == id);

            if (livro != null)
            {
                ReadLivroDto livroDto = _mapper.Map<ReadLivroDto>(livro);
                return Ok(livroDto);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaLivro([FromBody] UpdateLivroDto livroDto, int id)
        {
            Livro livro = _context.Livros.FirstOrDefault(livro => livro.Id == id);

            if (livro != null)
            {
                _mapper.Map(livroDto, livro);
                _context.SaveChanges();
                return NoContent();
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaLivro(int id)
        {
            Livro livro = _context.Livros.FirstOrDefault(livro => livro.Id == id);

            if (livro != null)
            {
                _context.Livros.Remove(livro);
                _context.SaveChanges();
                return NoContent();
            }
            return NotFound();
        }
    }
}
