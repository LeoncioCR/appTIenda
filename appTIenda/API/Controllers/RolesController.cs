using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Entidades;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RolesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetRolesMethod")]
        public async Task<ActionResult<IEnumerable<Rol>>> GetRolesMethod(string estadoRoles)
        {
            var listaRoles = await (from r in _context.Roles
                                    where r.EstadoRol == estadoRoles
                                    select r).ToListAsync();
            return Ok(listaRoles);
        }
    }
}
