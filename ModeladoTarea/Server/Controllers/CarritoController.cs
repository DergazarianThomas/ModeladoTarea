using Blazorapp5.BD.Data;
using Blazorapp5.BD.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModeladoTarea.Shared.DTO;

namespace ModeladoTarea.Server.Controllers
{
    [ApiController]
    [Route("api/Carrito")]
    public class CarritoController : ControllerBase
    {
        private readonly Context context;

        public CarritoController(Context context) 
        {
            this.context = context;
        }

        [HttpGet]

        public async Task<ActionResult<List<Carrito>>> Get()
        {
            var pepe = await context.Carritos.ToListAsync();
            if (pepe == null || pepe.Count == 0)
            {
                return BadRequest();
            }

            return pepe;
        }

        [HttpGet("{id:int}")]

        public async Task<ActionResult<Carrito>> Get(int id)
        {
            var existe = await context.Carritos.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound($"el Usuario de id={id} no existe");
            }

            return await context.Carritos.FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(CarritoDTO entidad)
        {
            Carrito pepe = new Carrito();

            pepe.UsuarioId = entidad.UsuarioId;


            await context.AddAsync(pepe);
            await context.SaveChangesAsync();
            return pepe.Id;
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Carrito carrito, int id)
        {
            if (id != carrito.Id)
            {
                return BadRequest("El Id de el Carrito no corresponde");
            }

            var existe = await context.Carritos.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound($"El Carrito de id={id} no existe");
            }

            context.Update(carrito);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]

        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Carritos.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound($"el Carrito de id={id} no existe");
            }

            context.Remove(new Carrito() { Id = id });
            await context.SaveChangesAsync();
            return Ok();
        }

    }
}
    

