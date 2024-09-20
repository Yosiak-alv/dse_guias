using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Entities.DTO
{
    public class LibroDto
    {
        public int Codigo { get; set; }

        [Required(ErrorMessage = "El título es requerido")]
        [StringLength(200, ErrorMessage = "El título no puede tener más de 200 caracteres")]
        public string Titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "La fecha de publicación es requerida")]
        public DateTime FechaPublicacion { get; set; }
        [Required(ErrorMessage = "El autor es requerido")]
        public int AutorID { get; set; }
        [Required(ErrorMessage = "La categoría es requerida")]
        public int CategoriaID { get; set; }


        public string NombreAutor { get; set; }
        public string NombreCategoria { get; set; }
    }
}
