using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entities.DTO
{
    public class AutorDto
    {
        public int Codigo { get; set; }
        [Required(ErrorMessage = "nombre requerido")]
        [StringLength(100, ErrorMessage = "no mas de 100 caracteres")]
        public string NombreAutor { get; set; } = string.Empty;
        [Required(ErrorMessage = "apellido requerido")]
        [StringLength(100, ErrorMessage = "no mas de 100 caracteres")]
        public string ApellidoAutor { get; set; } = string.Empty;
    }
}
