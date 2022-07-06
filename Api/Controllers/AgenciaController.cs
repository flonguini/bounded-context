using Infra.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

public class CriarAgenciaCommand
{
    public int Numero { get; set; }
    public string Endereco { get; set; }
}

public class CriarFaturamentoCommand
{
    public int AgenciaId { get; set; }
    public int Total { get; set; }
}

[Route("[controller]"), ApiController]
public class AgenciaController : ControllerBase
{
    [HttpGet()]
    public async Task<IActionResult> Get([FromServices] AgenciaContext context)
     => Ok(await context.Agencias.ToListAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromServices] AgenciaContext context, int id)
       => Ok(await context.Agencias.FirstOrDefaultAsync(a => a.Id == id));

    [HttpPost]
    public async Task<IActionResult> Create(
        [FromServices] AgenciaContext context, 
        CriarAgenciaCommand cmd)
    {
        var agencia = new Agencias.Agencia
        {
            Numero = cmd.Numero,
            Endereco = cmd.Endereco
        };

        await context.Agencias.AddAsync(agencia);
        var result = await context.SaveChangesAsync();
        if (result > 0)
            return Ok(agencia);
        return BadRequest();
    }
}

[Route("[controller]"), ApiController]
public class FaturamentoController : ControllerBase
{
    [HttpGet("{agenciaId}")]
    public async Task<IActionResult> Get([FromServices] FaturamentoContext context, int agenciaId)
     => Ok(await context.Agencias.Include(f => f.Faturamentos).Where(a => a.Id == agenciaId).ToListAsync());

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
