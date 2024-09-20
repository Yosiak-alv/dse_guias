using LibrosAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibrosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        private readonly LibrosDbContext _context;

        public LibrosController(LibrosDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Libro>> PostLibro(Libro libro)
        {
            if (string.IsNullOrEmpty(libro.Titulo))
            {
                return BadRequest("El titulo no puede estar vacio");
            }

            _context.Libros.Add(libro);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(PostLibro), new { id = libro.Id }, libro);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Libro>> GetLibro(int id)
        { 
            var libro = await _context.Libros.FindAsync(id);
            if (libro == null) 
            { 
                return NotFound();
            }
            return libro;
        }
        
    }
}
