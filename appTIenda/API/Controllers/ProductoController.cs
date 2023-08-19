using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Entidades;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetProductoPorNombreQuery")]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductoPorNombreQuery(string nomProducto)
        {
            var listaProducto = await (from p in _context.Productos.Include(p => p.Categoria)
                                       where p.NomProducto == nomProducto
                                       select p).ToListAsync();
            return Ok(listaProducto);
        }
    }
}
