using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Entities.Models
{
    public class Libro
    {
        [Key]
        public int id { get; set; }

        public string Titulo { get; set; }

        public DateTime FechaPublicacion { get; set; }

        public int AutorID { get; set; }

        public int CategoriaID { get; set; }
    }
}
