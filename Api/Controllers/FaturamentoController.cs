using Infra.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

[Route("[controller]"), ApiController]
public class FaturamentoController : ControllerBase
{
    [HttpGet("{agenciaId}")]
    public async Task<IActionResult> Get([FromServices] FaturamentoContext context, int agenciaId)
     => Ok(await context
         .Faturamento
         .Include(x => x.Agencia)
         .Where(x => x.AgenciaId == agenciaId)
         .ToArrayAsync());

    [HttpPost]
    public async Task<IActionResult> Create(
        [FromServices] FaturamentoContext context,
        CriarFaturamentoCommand cmd)
    {
        var faturamento = new Faturamentos.Faturamento()
        {
            Total = cmd.Total,
            AgenciaId = cmd.AgenciaId
        };
        
        await context.Faturamento.AddAsync(faturamento);
        var result = await context.SaveChangesAsync();
        if (result > 0)
            return Ok(faturamento);
        return BadRequest();
    }
}
