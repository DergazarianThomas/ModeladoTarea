using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazorapp5.BD.Data.Entity
{
    public class Rol
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El Nombre de Rol es obligatorio")]
        [MaxLength(45, ErrorMessage = "Solo se aceptan hasta 45 caracteres en el Nombre de Rol")]
        public string NombreRol { get; set; }

        public List<Usuario> Usuarios { get; set; } = new List<Usuario>();
    }
}
