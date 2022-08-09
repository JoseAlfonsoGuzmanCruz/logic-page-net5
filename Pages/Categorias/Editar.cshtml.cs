using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using logic_page_net5.Datos;
using logic_page_net5.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace logic_page_net5.Pages.Categorias
{
    public class EditarModel : PageModel
    {
        private readonly context _context;
        public EditarModel(context context)
        {
            _context = context;
        }
        [BindProperty]
        public Categoria Categorias { get; set; } 
        public async void OnGet(int id)
        {
            Categorias = await _context.Categorias.FindAsync(id);
        }
        public async Task<IActionResult> Onpost()
        {
            if (ModelState.IsValid)
            {
                var CategoriaDesdeDb = await _context.Categorias.FindAsync(Categorias.Id);
                CategoriaDesdeDb.Nombre = Categorias.Nombre;
                CategoriaDesdeDb.FechaCreacion = Categorias.FechaCreacion;

                await _context.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return RedirectToPage();
            }
        }
    }
}
