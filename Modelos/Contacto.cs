using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace logic_page_net5.Modelos
{
    public class Contacto
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre de categoria es obligatorio")]
        [StringLength(30, ErrorMessage = "{0} el nombre debe tener entre {2} y {1}", MinimumLength = 4)]
        public string Nombre { get; set; }

        //[Required(ErrorMessage = "El email de categoria es obligatorio")]
        [StringLength(30, ErrorMessage = "{0}nombre entre {2} y {1}", MinimumLength = 4)]
        public string Email { get; set; }

        //[Required(ErrorMessage = "El telefono de categoria es obligatorio")]
        [StringLength(30, ErrorMessage = "{0}nombre entre {2} y {1}", MinimumLength = 4)]
        public string Telefono { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha de creacion")]
        public DateTime? FechaCreacion { get; set; }


        //relacion con la categoria un [usuario pertenece a una catregoria] 
        [Required]
        public int CategoriaId { get; set; }
        //Instanciar categorias
        public Categoria Categorias { get; set; }
    }
}
