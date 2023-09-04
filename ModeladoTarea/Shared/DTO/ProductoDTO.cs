using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeladoTarea.Shared.DTO
{
    public class ProductoDTO
    {

        [MaxLength(1000, ErrorMessage = "Solo se aceptan hasta 1000 caracteres en la Descripcion")]
        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "El Nombre es obligatorio")]
        [MaxLength(255, ErrorMessage = "Solo se aceptan hasta 255 caracteres en el Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El Precio es obligatorio")]
        //[Precision(18, 2)]
        public decimal Precio { get; set; }

        public int CarritoId { get; set; }

    }
}
