using System.ComponentModel.DataAnnotations;

namespace Livraria.Data.Dtos.Editora
{
    public class UpdateEditoraDto
    {       
        [Required]
        public string Nome { get; set; }
    }
}
