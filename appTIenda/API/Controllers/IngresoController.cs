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
    public class IngresoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public IngresoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetProyectarIngresosQuery")]
        public async Task<ActionResult<IEnumerable<Ingreso>>> GetProyectarIngresosQuery()
        {
            var listaIngreso = await (from i in _context.Ingresos.Include(i => i.Usuario)
                                      select new IngresosDto
                                      {
                                          FechaIngrso = i.FechaIngreso,
                                          EstadoIngreso = i.EstadoIngreso,
                                          NombreUsuario = i.Usuario.NombreUsuario
                                      })
                                      .ToListAsync();
            return Ok(listaIngreso);
        }
    }
}
