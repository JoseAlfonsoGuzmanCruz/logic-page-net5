using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using logic_page_net5.Datos;
using logic_page_net5.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace logic_page_net5.Pages.Categorias
{
    public class IndexModel : PageModel
    {
        private readonly context _context;
        public IndexModel(context context)
        {
            _context = context;
        }
        public IEnumerable<Categoria> Categorias { get; set; }
        public async Task OnGet()
        {
            Categorias = await _context.Categorias.ToListAsync();
        }
    }
}
