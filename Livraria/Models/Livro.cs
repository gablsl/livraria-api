using System.ComponentModel.DataAnnotations;

namespace Livraria.Models
{
    public class Livro 
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Autor { get; set; }
        [Required]
        public string Genero { get; set; }
    }
}
