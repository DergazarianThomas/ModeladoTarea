using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeladoTarea.Shared.DTO
{
    public class CategoriaDTO
    {
        [Required]
        public string categoria { get; set; }

    }
}
