using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazorapp5.BD.Data.Entity
{
    public class ComprabanteDePago
    {
        [Key]
        public int Id { get; set; }
        public int NumeroComprabante { get; set; }

        public Compra Compra { get; set; }

        public int CompraId { get; set; }


    }
}
