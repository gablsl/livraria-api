﻿using System.ComponentModel.DataAnnotations;

namespace Livraria.Models
{
    public class Livro 
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo Título é obrigatório")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "O campo Autor é obrigatório")]
        public Autor Autor { get; set; }
        [Required(ErrorMessage = "O campo Gênero é obrigatório")]
        public string Genero { get; set; }
        [Required]
        public Editora Editora { get; set; }
    }
}
