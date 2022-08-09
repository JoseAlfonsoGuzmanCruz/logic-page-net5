using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using logic_page_net5.Datos;
using logic_page_net5.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace logic_page_net5.Pages.Contactos
{
    public class DetalleModel : PageModel
    {
        private readonly context _context;
        public DetalleModel(context context)
        {
            _context = context;
        }
        [BindProperty]
        public Contacto Contactos { get; set; }
        public async void OnGet(int id)
        {
            // using Microsoft.EntityFrameworkCore; => .Include()
            Contactos = await _context.contactos
                             .Where(c => c.Id == id)
                             .Include(c => c.Categorias)
                             .FirstOrDefaultAsync();
        }
    }
}
