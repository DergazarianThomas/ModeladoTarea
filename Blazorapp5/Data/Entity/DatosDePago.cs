using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazorapp5.BD.Data.Entity
{
    public class DatosDePago
    {
        [Key]
        public int Id { get; set; }

        public bool Envio { get; set; }
        public bool TipoDePago { get; set; }
    }
}
