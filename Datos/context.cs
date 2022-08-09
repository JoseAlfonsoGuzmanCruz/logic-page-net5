using logic_page_net5.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace logic_page_net5.Datos
{
    public class context:DbContext
    {
        public context(DbContextOptions<context> options) : base(options)
        {
        }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Contacto> contactos { get; set; }
    }
}
