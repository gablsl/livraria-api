using System.ComponentModel.DataAnnotations;

namespace Livraria.Models
{
    public class Editora
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        public Livro Livro { get; set; }
        public int LivroId { get; set; }
    }
}
