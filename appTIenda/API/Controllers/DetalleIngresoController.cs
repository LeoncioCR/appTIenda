using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Dtos;
using Models.Entidades;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleIngresoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DetalleIngresoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetProyectarDetalleIngresosQuery")]
        public async Task<ActionResult<IEnumerable<Detalle_Ingreso>>> GetProyectarDetalleIngresosQuery()
        {
            var listaIngreso = await (from i in _context.Detalle_Ingresos.Include(i => i.Producto).Include(i => i.Ingreso)
                                      select new DetalleIngresoDto
                                      {
                                          nombreProducto = i.Producto.NomProducto,
                                          nombreCategoria = i.Producto.Categoria.NomCategoria,
                                          Cantidad = i.CantidadDetaIngreso,
                                          Precio = i.PrecioDetaIngreso,
                                          fechaIngreso = i.Ingreso.FechaIngreso,
                                          NombreUsuario = i.Ingreso.Usuario.NombreUsuario
                                      })
                                      .ToListAsync();
            return Ok(listaIngreso);
        }
    }
}
