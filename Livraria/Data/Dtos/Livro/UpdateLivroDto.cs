﻿using System.ComponentModel.DataAnnotations;

namespace Livraria.Data.Dtos
{
    public class UpdateLivroDto
    {
        [Required(ErrorMessage = "O campo Título é obrigatório")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "O campo Autor é obrigatório")]
        public string Autor { get; set; }
        [Required(ErrorMessage = "O campo Gênero é obrigatório")]
        public string Genero { get; set; }
    }
}
