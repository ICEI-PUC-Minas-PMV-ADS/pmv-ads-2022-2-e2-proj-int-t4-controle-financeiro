using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZCaixaV5.Api.Data;
using ZCaixaV5.Models;

namespace ZCaixaV5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ZCaixaContexto _context;

        public UsuarioController(ZCaixaContexto contexto)
        {
            _context = contexto;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> Get()
        {
            return await _context.Usuarios.ToListAsync();
        }

        [HttpGet("{Username}")]
        public async Task<ActionResult<Usuario>> Get(string Username)
        {
            var usuario = await _context.Usuarios.FindAsync(Username);

            if (usuario == null )
            {
                return NotFound();
            }
            return usuario;

        }

        [HttpPost]
        public async Task<IActionResult> Post(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = usuario.Username }, usuario);
        }


    }
}
