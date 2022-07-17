using Infra.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Materiais;

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

public class CriarMaterialCommand
{
    public string Descricao { get; set; }
    public int SegmentoId { get; set; }
}

[Route("[controller]"), ApiController]
public class MateriaisController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromServices] MateriaisContext context,
        CriarMaterialCommand cmd)
    {
        var material = new Materiais.Material(cmd.SegmentoId, cmd.Descricao);

        await context.Materiais.AddAsync(material);
        var result = await context.SaveChangesAsync();
        if (result > 0)
            return Ok(material);
        return BadRequest();
    }

    [HttpGet()]
    public async Task<IActionResult> Get([FromServices] MateriaisContext context)
     => Ok(await context.Materiais.ToListAsync());
}

[Route("[controller]"), ApiController]
public class AgenciaController : ControllerBase
{
    [HttpGet()]
    public async Task<IActionResult> Get([FromServices] AgenciaContext context)
     => Ok(await context.Agencias.Include(x => x.Segmentos).ToListAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromServices] AgenciaContext context, int id)
       => Ok(await context.Agencias.FirstOrDefaultAsync(a => a.Id == id));
    
    [HttpGet("Segmentos")]
    public async Task<IActionResult> GetSegmentos([FromServices] AgenciaContext context)
       => Ok(await context.Segmentos.ToListAsync());

    [HttpPost]
    public async Task<IActionResult> Create(
        [FromServices] AgenciaContext context, 
        CriarAgenciaCommand cmd)
    {
        var agencia = new Agencias.Agencia(cmd.Numero, cmd.Endereco);

        await context.Agencias.AddAsync(agencia);
        var result = await context.SaveChangesAsync();
        if (result > 0)
            return Ok(agencia);
        return BadRequest();
    }
}
