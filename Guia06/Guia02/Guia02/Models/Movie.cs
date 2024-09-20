using System.ComponentModel.DataAnnotations;

namespace Guia02.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Display(Name = "Titulo")]
        [StringLength(60, MinimumLength =3)]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Fecha de lanzamiento")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime Datetime { get; set; }

        [Required]
        public int? GenreId { get; set; }

        [Display(Name = "Genero")]
        public Genre Genre { get; set; }

        [Display(Name = "Precio")]
        [Required]
        public decimal Price { get; set; }

        [Display(Name = "Director")]
        [StringLength(60, MinimumLength = 3)]
        [Range(1,100)]
        [Required]
        public string Director { get; set; }
    }
}
