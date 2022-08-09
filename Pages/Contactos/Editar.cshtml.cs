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
    public class EditarModel : PageModel
    {
        private readonly context _context;
        public EditarModel(context context)
        {
            _context = context;
        }
        [BindProperty]
        public CrearContactoVM ContactoVM { get; set; }
        public async Task<IActionResult> OnGet(int id)
        {
            ContactoVM = new CrearContactoVM()
            {
                // using Microsoft.EntityFrameworkCore
                ListaCategorias = await _context.Categorias.ToListAsync(),

                Contactos = await _context.contactos.FindAsync(id)

                //Contactos = new Modelos.Contacto()
            };
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)  // todas las validaciones estan correctas.
            {
                // var CategFound = await _contexto.Categorias.FindAsync(Categorias.Id);
                var ContactoFound = await _context.contactos.FindAsync(ContactoVM.Contactos.Id);
                // Grabar datos de Edit.
                ContactoFound.Nombre = ContactoVM.Contactos.Nombre;
                ContactoFound.Email = ContactoVM.Contactos.Email;
                ContactoFound.Telefono = ContactoVM.Contactos.Telefono;
                ContactoFound.CategoriaId = ContactoVM.Contactos.CategoriaId;
                ContactoFound.FechaCreacion = ContactoVM.Contactos.FechaCreacion;



                //await _contexto.Contactos.AddAsync(ContactoVM.Contactos);

                // Save on Database:
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
