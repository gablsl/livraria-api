using System.ComponentModel.DataAnnotations;

namespace Livraria.Data.Dtos.Editora
{
    public class CreateEditoraDto
    {
        [Required]
        public string Nome { get; set; }
    }
}
