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


    [HttpGet("servico/{dataServ}")]
    public async Task<ActionResult<IEnumerable<Servico>>> GetServicosByDate(DateTime dataServ)
    {
        var servicos = await _ServicoPersist.GetServicosByDate(dataServ);

        if (servicos == null || !servicos.Any())
        {
            return NotFound();
        }

        return Ok(servicos);
    }
      [HttpGet("servico/mecanico")]
    public async Task<ActionResult<IEnumerable<Servico>>> GetServicosByDate(string mecanico)
    {
        var servicos = await _ServicoPersist.GetServicosByMecanico(mecanico);

        if (servicos == null || !servicos.Any())
        {
            return NotFound();
        }

        return Ok(servicos);
    }
    [HttpGet("idServico/{idServico}")]
    public async Task<ActionResult<IEnumerable<Servico>>> GetServicoById(int idServico)
    {
        var servicos = await _ServicoPersist.GetServicoById(idServico);

        if (servicos == null)
        {
            return NotFound();
        }

        return Ok(servicos);
    }
}

}
