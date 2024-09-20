using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Biblioteca.Entities.DTO;
using Biblioteca.BL.Interfaces;
using System.Net;

namespace Desafio1.Controllers
{
    public class AutorController : Controller
    {
        private readonly IAutorService _autorService;

        public AutorController(IAutorService autorService)
        {
            _autorService = autorService;
        }

        // GET: /AutorMvc/Index
        public async Task<IActionResult> Index()
        {
            IEnumerable<AutorDto> autores = await _autorService.GetAutoresAsync();
            return View(autores);
        }

        // GET: 
        public async Task<IActionResult> Details(int id)
        {
            AutorDto autor = await _autorService.GetAutorByIdAsync(id);
            if (autor == null)
            {
                return NotFound();
            }
            return View(autor);
        }

        // GET: /AutorMvc/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /AutorMvc/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AutorDto autor)
        {
            if (ModelState.IsValid)
            {
                int result = await _autorService.InsertAutorAsync(autor);
                if (result > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(autor);
        }

        // GET: 
        public async Task<IActionResult> Edit(int id)
        {
            AutorDto autor = await _autorService.GetAutorByIdAsync(id);
            if (autor == null)
            {
                return NotFound();
            }
            return View(autor);
        }

        // POST: 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AutorDto autor)
        {
            if (id != autor.Codigo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                AutorDto updatedAutor = await _autorService.UpdateAutorAsync(autor);

                if (updatedAutor != null)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(autor);
        }

        // GET: 
        public async Task<IActionResult> Delete(int id)
        {
            AutorDto autor = await _autorService.GetAutorByIdAsync(id);
            if (autor == null)
            {
                return NotFound();
            }
            return View(autor);
        }

        // POST: 
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            bool result = await _autorService.DeleteAutorAsync(id);
            if (result)
            {
                return RedirectToAction(nameof(Index));
            }
            return BadRequest();
        }
    }
}
