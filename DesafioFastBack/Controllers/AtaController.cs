using DesafioFastBack.Models;
using DesafioFastBack.Data; // AppDbContext
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; //Include e ToListAsync

namespace DesafioFastBack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AtaController : ControllerBase
    {
        private readonly AppDbContext _context;

       
        public AtaController(AppDbContext context)
        {
            _context = context;
        }
        // Método para cadastrar uma nova Ata no banco
        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] AtaCreateDto dto)
        {
            // 1. Validar Workshop
            var workshopDoBanco = await _context.Workshops.FindAsync(dto.WorkshopId);
            if (workshopDoBanco == null)
                return NotFound("Workshop não encontrado.");
        
            // 2. Criar a instância da Model Ata (o ID será gerado pelo Banco)
            var novaAta = new Ata
            {
                workshop = workshopDoBanco,
                Colaborador = new List<Colaborador>()
            };
        
            // 3. Associar os Colaboradores pelos IDs enviados
            foreach (var id in dto.ColaboradoresIds)
            {
                var colab = await _context.Colaboradores.FindAsync(id);
                if (colab != null)
                {
                    novaAta.Colaborador.Add(colab);
                }
            }
        
            // 4. Salvar no Banco
            _context.Atas.Add(novaAta);
            await _context.SaveChangesAsync();
        
            return Created("", novaAta);
        }
        //Visualizar Workshop e Colaboradores juntos
        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            //  .Include traz os dados do Workshop e Colaboradores juntos (Join)
            var lista = await _context.Atas
                .Include(a => a.workshop)
                .Include(a => a.Colaborador)
                .ToListAsync();
            return Ok(lista);
        }
        //Adicionar um Colaborador a Ata
        [HttpPut("{ataId}/colaboradores/{colaboradorId}")]
        public async Task<IActionResult> AdicionarColaboradorNaAta(int ataId, int colaboradorId)
        {
            var ata = await _context.Atas
                .Include(a => a.Colaborador)
                .FirstOrDefaultAsync(a => a.Id == ataId);

            var colab = await _context.Colaboradores
                .FirstOrDefaultAsync(c => c.Id == colaboradorId);

            if (ata == null || colab == null) return NotFound("Ata ou Colaborador não existe.");

            if (!ata.Colaborador.Any(c => c.Id == colaboradorId))
            {
                ata.Colaborador.Add(colab);
                await _context.SaveChangesAsync(); // Salva o vínculo no banco
            }

            return Ok(ata);
        }
    }
}
