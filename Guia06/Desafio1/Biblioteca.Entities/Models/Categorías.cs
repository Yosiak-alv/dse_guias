using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Entities.Models
{
    public class Categorías
    {
        [Key]
        public int id { get; set; }
        public required string nombre { get; set; }
    }
}
