using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Biblioteca.Entities.DTO;
using Biblioteca.BL.Interfaces;
using System.Net;
using Microsoft.AspNetCore.Mvc.Rendering;
using Biblioteca.Entities.Models;
using AutoMapper;

namespace Desafio1.Controllers
{
    public class LibroController : Controller
    {
        private readonly ILibroService _libroService;
        private readonly IAutorService _autorService;
        private readonly ICategoriaService _categoriaService;
        private readonly IMapper _mapper;

        public LibroController(ILibroService libroService, IAutorService autorService, ICategoriaService categoriaService, IMapper mapper)
        {
            _libroService = libroService;
            _autorService = autorService;
            _categoriaService = categoriaService;
            _mapper = mapper;
        }

        // GET: /Libro/Index
        public async Task<IActionResult> Index()
        {
            IEnumerable<LibroDto> libros = await _libroService.GetLibrosAsync();
            return View(libros);
        }

        // GET:
        public async Task<IActionResult> Details(int id)
        {
            Libro libro = await _libroService.GetLibroByIdAsync(id);
            if (libro == null)
            {
                return NotFound();
            }
            return View(libro);
        }

        // GET: /Libro/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Autores = (await _autorService.GetAutoresAsync())
                              .Select(a => new SelectListItem
                              {
                                  Value = a.Codigo.ToString(),
                                  Text = a.NombreAutor
                              }).ToList();

            ViewBag.Categorias = (await _categoriaService.GetCategoriasAsync())
                                 .Select(c => new SelectListItem
                                 {
                                     Value = c.Codigo.ToString(),
                                     Text = c.NombreCategoria
                                 }).ToList();

            return View();
        }

        // POST: /Libro/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Libro libro)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int result = await _libroService.InsertLibroAsync(libro);

                    if (result > 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }

                    ModelState.AddModelError("", "No se pudo crear el libro. Intente de nuevo.");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Error: {ex.Message}");
                }
            }
            ViewBag.Autores = (await _autorService.GetAutoresAsync())
                              .Select(a => new SelectListItem
                              {
                                  Value = a.Codigo.ToString(),
                                  Text = a.NombreAutor
                              }).ToList();

            ViewBag.Categorias = (await _categoriaService.GetCategoriasAsync())
                                 .Select(c => new SelectListItem
                                 {
                                     Value = c.Codigo.ToString(),
                                     Text = c.NombreCategoria
                                 }).ToList();

            return View(libro);
        }

        // GET: 
        public async Task<IActionResult> Edit(int id)
        {
            var libro = await _libroService.GetLibroByIdAsync(id);
            if (libro == null)
            {
                return NotFound();
            }

            ViewBag.Autores = (await _autorService.GetAutoresAsync())
                              .Select(a => new SelectListItem
                              {
                                  Value = a.Codigo.ToString(),
                                  Text = a.NombreAutor,
                                  Selected = a.Codigo == libro.AutorID
                              }).ToList();

            ViewBag.Categorias = (await _categoriaService.GetCategoriasAsync())
                                 .Select(c => new SelectListItem
                                 {
                                     Value = c.Codigo.ToString(),
                                     Text = c.NombreCategoria,
                                     Selected = c.Codigo == libro.CategoriaID
                                 }).ToList();

            return View(libro);
        }

        // POST:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Libro libro)
        {
            if (id != libro.id)  
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _libroService.UpdateLibroAsync(libro);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Error: {ex.Message}");
                }
            }
            ViewBag.Autores = (await _autorService.GetAutoresAsync())
                              .Select(a => new SelectListItem
                              {
                                  Value = a.Codigo.ToString(),
                                  Text = a.NombreAutor,
                                  Selected = a.Codigo == libro.AutorID
                              }).ToList();

            ViewBag.Categorias = (await _categoriaService.GetCategoriasAsync())
                                 .Select(c => new SelectListItem
                                 {
                                     Value = c.Codigo.ToString(),
                                     Text = c.NombreCategoria,
                                     Selected = c.Codigo == libro.CategoriaID
                                 }).ToList();

            return View(libro);
        }

        // GET: 
        public async Task<IActionResult> Delete(int id)
        {
            var libro = await _libroService.GetLibroByIdAsync(id);
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        // POST:
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            bool result = await _libroService.DeleteLibroAsync(id);
            if (result)
            {
                return RedirectToAction(nameof(Index));
            }

            return BadRequest();
        }
    }
}
