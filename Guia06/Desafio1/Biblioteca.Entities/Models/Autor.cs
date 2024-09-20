using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entities.Models
{
    public class Autor
    {
        [Key]
        public int id { get; set; }
        public required string nombre { get; set; }
        public required string apellido { get; set; }
    }
}
