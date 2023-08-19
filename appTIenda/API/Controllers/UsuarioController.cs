using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Entidades;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsuarioController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetEstadoUsuarioQuery")]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetEstadoUsuarioQuery(string tipoDocumento)
        {
            var filtroTipoDocumento = $"{tipoDocumento}";
            
            var listaUsuario = await (from u in _context.Usuarios.Include(u => u.Rol)
                                      where EF.Functions.Like(u.TipoDocumento, filtroTipoDocumento)
                                      select u).ToListAsync();
            return Ok(listaUsuario);
        }
    }
}
