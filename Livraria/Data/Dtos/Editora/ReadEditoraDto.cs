using System.ComponentModel.DataAnnotations;

namespace Livraria.Data.Dtos.Editora
{
    public class ReadEditoraDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
    }
}
