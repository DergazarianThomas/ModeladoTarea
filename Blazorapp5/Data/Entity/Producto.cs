using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Blazorapp5.BD.Data.Entity
{

    [Index(nameof(codigo), Name = "Producto_codigo_UQ", IsUnique = true)]
    public class Producto
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "El CODIGO del PRODUCTO es Obligatorio")]
        [MaxLength(20, ErrorMessage = "Solo se aceptan hasta 20 caracteres en el CODIGO")]
        public string codigo { get; set; }

        [Required(ErrorMessage = "El CODIGO del PRODUCTO es Obligatorio")]
        [MaxLength(20, ErrorMessage = "Solo se aceptan hasta 4 caracteres en el CODIGO")]
        public int categoria { get; set; }

        [Required(ErrorMessage = "El Nombre es obligatorio")]
        [MaxLength(255, ErrorMessage = "Solo se aceptan hasta 255 caracteres en el Nombre")]
        public string nombre { get; set; }

        [MaxLength(1000, ErrorMessage = "Solo se aceptan hasta 1000 caracteres en la Descripcion")]
        public string? descripcion { get; set; }

        [Required(ErrorMessage = "El Precio es obligatorio")]
        [Precision(18, 2)]
        public decimal precio { get; set; }

        [Required(ErrorMessage = "La cantidad es obligatoria")]
        [Range(1, int.MaxValue, ErrorMessage = "El campo {0} es requerido")]
        public int cantidad { get; set; }

        public int categoriaId { get; set; }
        public Categoria Categorias { get; set; }
    }
}
