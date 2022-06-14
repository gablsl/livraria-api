using AutoMapper;
using Livraria.Data;
using Livraria.Data.Dtos.Editora;
using Livraria.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Linq;

namespace Livraria.Controllers
{
    [ApiController]
    [Route("/v1/editora")]
    public class EditoraController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public EditoraController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaEditora([FromBody] CreateEditoraDto editoraDto)
        {
            Editora editora = _mapper.Map<Editora>(editoraDto);

            _context.Editoras.Add(editora);
            _context.SaveChanges();
            return CreatedAtAction(nameof(PesquisaEditoraPorId), new { id = editora.Id }, editora);
        }

        [HttpGet]
        public IEnumerable PesquisaEditora()
        {
            return _context.Editoras;
        }

        [HttpGet("{id}")]
        public IActionResult PesquisaEditoraPorId(int id)
        {
            Editora editora = _context.Editoras.FirstOrDefault(editora => editora.Id == id);

            if (editora != null)
            {
                ReadEditoraDto editoraDto = _mapper.Map<ReadEditoraDto>(editora);
                return Ok(editora);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaEditora([FromBody] UpdateEditoraDto editoraDto, int id)
        {
            Editora editora = _context.Editoras.FirstOrDefault(editora => editora.Id == id);

            if (editora != null)
            {
                _mapper.Map(editoraDto, editora);
                _context.SaveChanges();
                return NoContent();
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaEditora(int id)
        {
            Editora editora = _context.Editoras.FirstOrDefault(editora => editora.Id == id);

            if (editora != null)
            {
                _context.Editoras.Remove(editora);
                _context.SaveChanges();
                return NoContent();
            }
            return NotFound();
        }
    }
}
