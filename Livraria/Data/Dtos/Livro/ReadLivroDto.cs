using System;
using System.ComponentModel.DataAnnotations;

namespace Livraria.Data.Dtos
{
    public class ReadLivroDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo Título é obrigatório")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "O campo Autor é obrigatório")]
        public string Autor { get; set; }
        [Required(ErrorMessage = "O campo Gênero é obrigatório")]
        public string Genero { get; set; }
        public DateTime HoraDaConsulta { get; set; }
    }
}
