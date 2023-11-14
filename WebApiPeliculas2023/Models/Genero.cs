﻿using System.ComponentModel.DataAnnotations;

namespace WebApiPeliculas2023.Models
{
	public class Genero
	{
        public int Id { get; set; }
		[Required(ErrorMessage = "El campo {0} es requerido")]
		[StringLength(maximumLength: 50, ErrorMessage = "El campo {0} no debe de tener más de {1} caracteres")]
		public string Nombre { get; set; }


    }
}
