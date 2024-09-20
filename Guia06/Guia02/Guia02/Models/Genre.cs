using System.ComponentModel.DataAnnotations;

namespace Guia02.Models
{
    public class Genre
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }
}
