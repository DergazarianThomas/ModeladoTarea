using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeladoTarea.Shared.DTO
{
    public class UsuariosDTO
    {

        [Required(ErrorMessage = "El Nombre de Usuario es obligatorio")]
        [MaxLength(32, ErrorMessage = "Solo se aceptan hasta 32 caracteres en el Usuario")]
        public string NombreUsuario { get; set; }

        [Required(ErrorMessage = "La contrasena es obligatoria")]
        [MaxLength(32, ErrorMessage = "Solo se aceptan hasta 32 caracteres en la contrasena")]

        public string Contrasena { get; set; }

        [Required(ErrorMessage = "El Email es obligatorio")]
        [MaxLength(255, ErrorMessage = "Solo se aceptan hasta 255 caracteres en el Email")]

        public string Email { get; set; }

        [Required(ErrorMessage = "El DNI es obligatorio")]
        public int Dni { get; set; }

        [Required(ErrorMessage = "El domicilio es obligatorio")]
        [MaxLength(255, ErrorMessage = "Solo se aceptan hasta 255 caracteres en el Domicilio")]

        public string Domiciliio { get; set; }

        [Required(ErrorMessage = "El Nombre es obligatorio")]
        [MaxLength(45, ErrorMessage = "Solo se aceptan hasta 45 caracteres en el Nombre")]

        public string Nombre { get; set; }

        [Required(ErrorMessage = "El Apellido es obligatorio")]
        [MaxLength(45, ErrorMessage = "Solo se aceptan hasta 45 caracteres en el Apellido")]

        public string Apellido { get; set; }

        [Required(ErrorMessage = "El Rol es obligatorio")]
        public int RolId { get; set; }


    }
}
