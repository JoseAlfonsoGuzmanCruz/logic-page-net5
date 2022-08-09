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
    public class BorrarModel : PageModel
    {
        private readonly context _context;
        public BorrarModel(context context)
        {
            _context = context;
        }
        [BindProperty]
        public CrearContactoVM ContactoVM { get; set; }
        public async Task<IActionResult> OnGet(int id)
        {
            ContactoVM = new CrearContactoVM()
            {
                ListaCategorias = await _context.Categorias.ToListAsync(),
                //Contactos = new Modelos.Contacto()
                Contactos = await _context.contactos.FindAsync(id) //  <---- Find(id)
            };
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            var ContactoFound = await _context.contactos.FindAsync(ContactoVM.Contactos.Id);

            if (ContactoFound == null)
            {
                return NotFound();
            }
            else
            {

                _context.contactos.Remove(ContactoFound);

                // await _contexto.Categorias.AddAsync(Categorias);    solo Display, esto NO.

                // Save on Database:
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("Index");
        }
    }
}
