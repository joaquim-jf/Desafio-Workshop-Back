using DesafioFastBack.Models;
using DesafioFastBack.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesafioFastBack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ColaboradorController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ColaboradorController(AppDbContext context)
        {
            _context = context;
        }
        // Método para cadastrar um novo colaborador no banco
        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] Colaborador novoColaborador)
        {
            _context.Colaboradores.Add(novoColaborador);
            await _context.SaveChangesAsync();
            return Created("", novoColaborador);
        }

        // Endpoint principal: lista colaboradores e  workshops

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var colaboradores = await _context.Colaboradores
                .OrderBy(c => c.Nome)// Organiza em ordem alfabética (A-Z)
                .Select(c => new {
                    c.Id,
                    c.Nome,
                    
                    Workshops = _context.Atas
                        .Where(a => a.Colaborador.Any(colab => colab.Id == c.Id))
                        .Select(a => a.workshop)
                        .ToList()
                })
                .ToListAsync();

            return Ok(colaboradores);
        }
    }
}