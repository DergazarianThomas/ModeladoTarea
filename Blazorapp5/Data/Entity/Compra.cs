using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazorapp5.BD.Data.Entity
{
    public class Compra
    {
        [Key]
        public int Id { get; set; }

        public Carrito Carrito { get; set; }

        public int CarritoId { get; set; }

        public DatosDePago DatosDePago { get; set; }

        public int DatosDePagoId { get; set; }


    }
}
