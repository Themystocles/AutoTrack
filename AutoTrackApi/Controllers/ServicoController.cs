using AutoTrackApi.Interface;
using AutoTrackApi.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoTrack.Controllers
{
    [ApiController]
[Route("api/[controller]")]
public class ServicoController : ControllerBase
{
    private readonly IGeralPersist _geralPersist;
    private readonly IServicoPersist _ServicoPersist;

    public ServicoController(IGeralPersist geralPersist, IServicoPersist servicoPersist)
    {
        _geralPersist = geralPersist;
        _ServicoPersist = servicoPersist;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Servico>>> GetServicos()
    {
        var servicos = await _geralPersist.GetAll<Servico>();
        return Ok(servicos);
    }

   /* [HttpPost]
    public async Task<IActionResult> PostServico([FromBody] Servico servico)
    {
        if (servico == null)
        {
            return BadRequest("Serviço is null");
        }

        await _geralPersist.AddAsync(servico);
        return CreatedAtAction(nameof(GetServicos), new { id = servico.Id }, servico);
    }*/

    [HttpGet("servico/{dataServ}")]
    public async Task<ActionResult<IEnumerable<Servico>>> GetServicosByDate(string dataServ)
    {
        var servicos = await _ServicoPersist.GetServicosByDate(dataServ);

        if (servicos == null || !servicos.Any())
        {
            return NotFound();
        }

        return Ok(servicos);
    }
}

}
