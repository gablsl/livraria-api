using System.ComponentModel.DataAnnotations;

namespace Livraria.Models
{
    public class Autor
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo Idade é obrigatório")]
        public int Idade { get; set; }
        [Required(ErrorMessage = "O campo Sexo é obrigatório")]
        [MaxLength(1)]
        public string Sexo { get; set; }
    }
}
