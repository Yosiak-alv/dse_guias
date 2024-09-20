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
    public class CategoriaController : Controller
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        // GET: /AutorMvc/Index
        public async Task<IActionResult> Index()
        {
            IEnumerable<CategoríasDto> categorias = await _categoriaService.GetCategoriasAsync();
            return View(categorias);
        }

        // GET: 
        public async Task<IActionResult> Details(int id)
        {
            CategoríasDto categoria = await _categoriaService.GetCategoriaByIdAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return View(categoria);
        }

        // GET: /AutorMvc/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /AutorMvc/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoríasDto categoria)
        {
            if (ModelState.IsValid)
            {
                int result = await _categoriaService.InsertCategoriaAsync(categoria);
                if (result > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(categoria);
        }

        // GET: 
        public async Task<IActionResult> Edit(int id)
        {
            CategoríasDto categoria = await _categoriaService.GetCategoriaByIdAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return View(categoria);
        }

        // POST: 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CategoríasDto categoria)
        {
            if (id != categoria.Codigo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                CategoríasDto updatedCategoria = await _categoriaService.UpdateCategoriaAsync(categoria);

                if (updatedCategoria != null)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(categoria);
        }

        // GET: 
        public async Task<IActionResult> Delete(int id)
        {
            CategoríasDto categoria = await _categoriaService.GetCategoriaByIdAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return View(categoria);
        }

        // POST: 
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            bool result = await _categoriaService.DeleteCategoriaAsync(id);
            if (result)
            {
                return RedirectToAction(nameof(Index));
            }
            return BadRequest();
        }
    }
}
