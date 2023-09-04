using Blazorapp5.BD.Data;
using Blazorapp5.BD.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ModeladoTarea.Server.Controllers
{
    [ApiController]
    [Route("api/Rol")]
    public class RolController : ControllerBase
    {
        private readonly Context context;

        public RolController(Context context)
        {
            this.context = context;
        }

        [HttpGet]

        public async Task<ActionResult<List<Rol>>> Get()
        {


            return await context.Roles.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Rol rol)
        {
            context.Add(rol);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Rol rol, int id)
        {
            if (id != rol.Id)
            {
                return BadRequest("El Id de el Rol no corresponde");
            }

            var existe = await context.Roles.AnyAsync(x => x.Id==id);
            if (!existe)
            {
                return NotFound($"El Rol de id={id} no existe");
            }

            context.Update(rol);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]

        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Roles.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound($"el Rol de id={id} no existe");
            }

            context.Remove(new Rol() {Id = id});
            await context.SaveChangesAsync();
            return Ok();
        }

    }
}
