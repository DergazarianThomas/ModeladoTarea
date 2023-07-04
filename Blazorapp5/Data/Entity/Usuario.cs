using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazorapp5.BD.Data.Entity
{
    public class Usuario
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El Nombre de Usuario es obligatorio")]
        [MaxLength(32, ErrorMessage = "Solo se aceptan hasta 32 caracteres en el Usuario")]
        public string NombreUsuario { get; set; }

        [Required(ErrorMessage = "La contrasena es obligatoria")]
        [MaxLength(16, ErrorMessage = "Solo se aceptan hasta 16 caracteres en la contrasena")]

        public string Contrasena { get; set; }

        [Required(ErrorMessage = "El Email es obligatorio")]
        [MaxLength(160, ErrorMessage = "Solo se aceptan hasta 160 caracteres en el Email")]

        public string Email { get; set; }

        [Required(ErrorMessage = "El DNI es obligatorio")]
        [MaxLength(8, ErrorMessage = "Solo se aceptan hasta 8 caracteres en el Email")]

        public string Dni { get; set; }

        [Required(ErrorMessage = "El domicilio es obligatorio")]
        [MaxLength(100, ErrorMessage = "Solo se aceptan hasta 100 caracteres en el Domicilio")]

        public string Domiciliio { get; set; }

        [Required(ErrorMessage = "El Nombre es obligatorio")]
        [MaxLength(45, ErrorMessage = "Solo se aceptan hasta 45 caracteres en el Nombre")]

        public string Nombre { get; set; }

        [Required(ErrorMessage = "El Apellido es obligatorio")]
        [MaxLength(45, ErrorMessage = "Solo se aceptan hasta 45 caracteres en el Email")]

        public string Apellido { get; set; }

        public Rol Rol { get; set; }

        public int RolId { get; set; }

    }
}
