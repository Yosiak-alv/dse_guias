using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Guia02.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Guia02DBContext(
            serviceProvider.GetRequiredService<DbContextOptions<Guia02DBContext>>()))
            {
                if (context.Movies.Any())
                {
                    return;
                }

                context.Genres.AddRange(
                    new Genre
                    {
                        Name = "Ciencia Ficcion",
                        //Id = 1,
                    },
                    new Genre
                    {
                        Name = "Anime",
                        //Id = 2,
                    },
                    new Genre
                    {
                        Name = "Fantasia",
                        //Id = 3,
                    }
                );

                context.Movies.AddRange(
                    new Movie
                    {
                        Name = "Star Wars Episodio III",
                        Datetime = DateTime.Parse("2003-11-16"),
                        GenreId = 1,
                        Price = 9.99M,
                        Director = "George Lucas"
                    },
                    new Movie
                    {
                        Name = "Dragon Ball Super: Broly",
                        Datetime = DateTime.Parse("2020-11-16"),
                        GenreId = 2,
                        Price = 9.99M,
                        Director = "Akira Toriyama"
                    },
                    new Movie
                    {
                        Name = "Shrek 2",
                        Datetime = DateTime.Parse("2003-11-16"),
                        GenreId = 3,
                        Price = 9.99M,
                        Director = "Andrew Adamson"
                    }
                );

                
                context.SaveChanges();
            }
        }
    }
}
