using Livraria.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Livraria.Controllers
{
    public class LivroController : ControllerBase
    {
        public List<Livro> livros = new List<Livro>();
        private static int id = 1;

        [HttpPost]
        public IActionResult AdicionaLivro(Livro livro)
        {
            livros.Add(livro);
            livro.Id = id++;
            return CreatedAtAction(nameof(PesquisaLivroPorId), new { id = livro.Id }, livro);
        }

        [HttpGet]
        public IActionResult PesquisaLivro()
        {
            return Ok(livros);
        }

        [HttpGet("{id}")]
        public IActionResult PesquisaLivroPorId(int id)
        {
            Livro livro = livros.FirstOrDefault(l => l.Id == id);

            if (livro != null)
            {
                return Ok(livro);
            }
            return NotFound();
        }
    }
}
