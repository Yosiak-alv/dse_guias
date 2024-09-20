using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Entities.DTO
{
    public class CategoríasDto
    {
        public int Codigo { get; set; }
        [Required(ErrorMessage = "nombre requerido")]
        [StringLength(100, ErrorMessage = "no mas de 100 caracteres")]
        public string NombreCategoria { get; set; } = string.Empty;
    }
}
