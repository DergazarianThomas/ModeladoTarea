using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazorapp5.BD.Data.Entity
{
    public class Categoria
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "La CATEGORIA del PRODUCTO es obligatorio")]
        public string categoria { get; set; }

        public List<Producto> Productos { get; set; } = new List<Producto>();
    }
}