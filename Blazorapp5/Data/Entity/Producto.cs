using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazorapp5.BD.Data.Entity
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(255, ErrorMessage = "Solo se aceptan hasta 255 caracteres en la Descripcion")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El Nombre es obligatorio")]
        [MaxLength(64, ErrorMessage = "Solo se aceptan hasta 64 caracteres en el Descripcion")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El Precio es obligatorio")]
        [MaxLength(20, ErrorMessage = "Solo se aceptan hasta 20 caracteres en el Precio")]
        [Precision(18, 2)]
        public decimal Precio { get; set; }

        public Carrito Carrito { get; set; }

        public int CarritoId { get; set; }
    }
}
