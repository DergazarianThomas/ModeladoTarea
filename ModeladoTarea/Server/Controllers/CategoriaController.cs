using Blazorapp5.BD.Data;
using Blazorapp5.BD.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModeladoTarea.Shared.DTO;

namespace ModeladoTarea.Server.Controllers
{
    [ApiController]
    [Route("api/Categoria")]
    public class CategoriaController : ControllerBase
    {
        private readonly Context context;

        public CategoriaController(Context context) 
        { 
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Categoria>>> Get()
        {
            var lista = await context.Categorias.ToListAsync();
            if (lista == null || lista.Count == 0)
            {
                return BadRequest();
            }

            return lista;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Categoria?>> Get(int id)
        {
            var existe = await context.Categorias.AnyAsync(x => x.id == id);
            if (!existe)
            {
                return NotFound($"La Categoria {id} no existe");
            }
            return await context.Categorias.FirstOrDefaultAsync(ped => ped.id == id);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Categoria categoria)
        {
            context.Add(categoria);
            await context.SaveChangesAsync();
            return categoria.id;
        }

        [HttpPut("{id:int}")] // api/roles/2
        public async Task<ActionResult> Put(Categoria categoria, int id)
        {
            if (id != categoria.id)
            {
                return BadRequest("El id de la categoria no corresponde");
            }

            var existe = await context.Categorias.AnyAsync(x => x.id == id);
            if (!existe)
            {
                return NotFound($"La categoria de id={id} no existe");
            }

            context.Update(categoria);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Categorias.AnyAsync(x => x.id == id);
            if (!existe)
            {
                return NotFound($"La categoria de id={id} no existe");
            }

            context.Remove(new Categoria() { id = id });
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
