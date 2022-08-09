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
    public class IndexModel : PageModel
    {
        private readonly context _context;
        public IndexModel(context context)
        {
            _context = context;
        }
        public IEnumerable<Contacto> Contactos { get; set; }
        public async Task OnGet()
        {
            Contactos = await _context.contactos.Include(c => c.Categorias).ToListAsync();
        }
    }
}
