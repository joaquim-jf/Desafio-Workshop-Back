using DesafioFastBack.Data;
using DesafioFastBack.Models;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesafioFastBack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkshopController : ControllerBase
    {
        // Variável que guarda a conexão com o banco de dados
        private readonly AppDbContext _context;
        
        // Construtor: recebe o banco de dados
        public WorkshopController(AppDbContext context)
        {
            _context = context;
        }
        // Método para cadastrar um novo Workshop no banco
        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] Workshop novoWorkshop)
        {
            _context.Workshops.Add(novoWorkshop);
            //Salva as mudanças de verdade no SQL Server
            await _context.SaveChangesAsync();
            // Retorna o status 201 (Criado) e os dados.
            return Created("", novoWorkshop);
        }

    }
}