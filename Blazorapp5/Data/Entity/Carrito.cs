using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazorapp5.BD.Data.Entity
{
    public class Carrito
    {
        [Key]
        public int Id { get; set; }

        public Usuario Usuario { get; set; }

        public int UsuarioId { get; set; }
         
        public List<Producto> Productos { get; set; } = new  List<Producto>();
    }
}
