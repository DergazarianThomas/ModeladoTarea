using Blazorapp5.BD.Data;
using Blazorapp5.BD.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModeladoTarea.Shared.DTO;

namespace ModeladoTarea.Server.Controllers
{
    [ApiController]
    [Route("api/Usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly Context context;

        public UsuarioController(Context context)
        {
            this.context = context;
        }

        [HttpGet]
        
        public async Task<ActionResult<List<Usuario>>> Get()
        {
            var pepe = await context.Usuarios.ToListAsync();
            if (pepe == null || pepe.Count == 0)
            {
                return BadRequest();
            }

            return pepe;
        }

        [HttpGet("{id:int}")]

        public async Task<ActionResult<Usuario>> Get(int id)
        {
            var existe = await context.Usuarios.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound($"el Usuario de id={id} no existe");
            }

            return await context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(UsuariosDTO entidad)
        {
            Usuario pepe = new Usuario();

            pepe.NombreUsuario = entidad.NombreUsuario;
            pepe.Contrasena = entidad.Contrasena;
            pepe.Email = entidad.Email;
            pepe.Dni = entidad.Dni;
            pepe.Domiciliio =  entidad.Domiciliio;
            pepe.Nombre = entidad.Nombre;
            pepe.Apellido = entidad.Apellido;
            pepe.RolId = entidad.RolId;

            await context.AddAsync(pepe);
            await context.SaveChangesAsync();
            return pepe.Id;
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Usuario usuario, int id)
        {
            if (id != usuario.Id)
            {
                return BadRequest("El Id de el Usuario no corresponde");
            }

            var existe = await context.Usuarios.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound($"El Usuario de id={id} no existe");
            }

            context.Update(usuario);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]

        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Usuarios.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound($"el Usuario de id={id} no existe");
            }

            context.Remove(new Usuario() { Id = id });
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
