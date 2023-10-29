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
            var lista = await context.Productos.ToListAsync();
            if (lista == null || lista.Count == 0)
            {
                return BadRequest();
            }

            return lista;
        }

        [HttpGet("{id:int}")]

        public async Task<ActionResult<Producto>> Get(int id)
        {
            var existe = await context.Productos.AnyAsync(x => x.id == id);
            if (!existe)
            {
                return NotFound($"el Producto de id={id} no existe");
            }

            return await context.Productos.FirstOrDefaultAsync(x => x.id == id);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(ProductoDTO entidad)
        {
            try
            {
                var existe = await context.Categorias.AnyAsync(x => x.id == entidad.categoriaId);
                if (!existe)
                {
                    return NotFound($"La categoria de id={entidad.categoriaId} no existe");
                }

                Producto nuevoproducto = new Producto();

                nuevoproducto.codigo = entidad.codigo;
                nuevoproducto.nombre = entidad.nombre;
                nuevoproducto.descripcion = entidad.descripcion;
                nuevoproducto.precio = entidad.precio;
                nuevoproducto.cantidad = entidad.cantidad;
                nuevoproducto.categoriaId = entidad.categoriaId;


                await context.AddAsync(nuevoproducto);
                await context.SaveChangesAsync();
                return nuevoproducto.id;


            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(ProductoDTO productoDTO, int id)
        {
            //comprobar que ese id exista en la base de datos
            var exist = await context.Productos.AnyAsync(e => e.id == id);
            if (!exist)
            {
                return BadRequest("El Producto no existe");
            }

            Producto entidad = new Producto();
            entidad.id = id;
            entidad.codigo = productoDTO.codigo;
            entidad.nombre = productoDTO.nombre;
            entidad.descripcion = productoDTO.descripcion;
            entidad.cantidad = productoDTO.cantidad;
            entidad.precio = productoDTO.precio;
            entidad.categoriaId = productoDTO.categoriaId;
        

            //actualizar
            context.Update(entidad);
            await context.SaveChangesAsync();
            return Ok("Actualizado con Exito");
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Productos.AnyAsync(x => x.id == id);
            if (!existe)
            {
                return NotFound($"El producto con el ID={id} no existe");
            }

            context.Remove(new Producto() { id = id });
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}