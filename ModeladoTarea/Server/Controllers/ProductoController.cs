using Blazorapp5.BD.Data;
using Blazorapp5.BD.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using ModeladoTarea.Shared.DTO;

namespace ModeladoTarea.Server.Controllers
{
    [ApiController]
    [Route("api/Producto")]
    public class ProductoController : ControllerBase
    {
        private readonly Context context;

        public ProductoController(Context context)
        {
            this.context = context;
        }

        [HttpGet]

        public async Task<ActionResult<List<Producto>>> Get()
        {
            var pepe = await context.Productos.ToListAsync();
            if (pepe == null || pepe.Count == 0)
            {
                return BadRequest();
            }

            return pepe;
        }

        [HttpGet("{id:int}")]

        public async Task<ActionResult<Producto>> Get(int id)
        {
            var existe = await context.Productos.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound($"el Producto de id={id} no existe");
            }

            return await context.Productos.FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(ProductoDTO entidad)
        {
            Producto pepe = new Producto();

            pepe.Nombre = entidad.Nombre;
            pepe.Descripcion = entidad.Descripcion;
            pepe.Precio = entidad.Precio;
            pepe.CarritoId = entidad.CarritoId;


            await context.AddAsync(pepe);
            await context.SaveChangesAsync();
            return pepe.Id;
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Producto producto, int id)
        {
            if (id != producto.Id)
            {
                return BadRequest("El Id de el Producto no corresponde");
            }

            var existe = await context.Productos.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound($"El Producto de id={id} no existe");
            }

            context.Update(producto);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]

        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Productos.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound($"el Producto de id={id} no existe");
            }

            context.Remove(new Producto() { Id = id });
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
