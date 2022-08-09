using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using logic_page_net5.Datos;
using logic_page_net5.Modelos.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace logic_page_net5.Pages.Contactos
{
    public class CrearModel : PageModel
    {
        private readonly context _context;
        public CrearModel(context context)
        {
            _context = context;
        }
        [BindProperty]
        public CrearContactoVM ContactoVM { get; set; }
        public async Task<IActionResult> OnGet()
        {
            ContactoVM = new CrearContactoVM()
            {
                ListaCategorias = await _context.Categorias.ToListAsync(),
                Contactos = new Modelos.Contacto()
            };
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _context.contactos.AddAsync(ContactoVM.Contactos);
                await _context.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
