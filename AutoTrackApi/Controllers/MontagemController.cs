using AutoTrackApi.Interface;
using AutoTrackApi.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoTrackApi.Controllers
{
    [Route("api/[controller]")]
    public class MontagemController : ControllerBase
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IMontagemPersist _MontagemPersist;

         public MontagemController(IGeralPersist geralPersist, IMontagemPersist montagemPersist)
    {
        _geralPersist = geralPersist;
        _MontagemPersist = montagemPersist;
    }

   [HttpGet]
    public async Task<ActionResult<IEnumerable<Montagem>>> GetMontagem()
    {
        var montagem = await _geralPersist.GetAll<Montagem>();
        return Ok(montagem);
    }

   

    [HttpGet("montagem/{datamont}")]
    public async Task<ActionResult<IEnumerable<Montagem>>> GetMontbyData(DateTime dataMont)
    {
        var montagem = await _MontagemPersist.GetMontagemsByData(dataMont);

        if (montagem == null || !montagem.Any())
        {
            return NotFound();
        }

        return Ok(montagem);
    }
       [HttpGet("idmontagem/{idMontagem}")]
    public async Task<ActionResult<IEnumerable<Montagem>>> GetServicoById(int idMontagem)
    {
        var Montagem = await _MontagemPersist.GetMontagemById(idMontagem);

        if (Montagem == null)
        {
            return NotFound();
        }

        return Ok(Montagem);
    }

    [HttpGet("montagem/nao-pagos")]
public async Task<IActionResult> GetCountServicosNaoPagos()
{
    var count = await _MontagemPersist.GetCountMontagensNaoPagos();
    return Ok(count);
}
[HttpGet("listMontagens/nao-pagos")]
public async Task<IActionResult> getServicosnãopagos()
{
    var montagem = await _MontagemPersist.GetMontagensNaoPagos();
    return Ok(montagem);
}

[HttpGet("montagem/instaladores")]
public async Task<ActionResult <IEnumerable<Montagem>>> GetMontagembyInstaladores(string instalador){

    var montagem = await _MontagemPersist.GetMontagensByMecanico(instalador);

       if (montagem == null || !montagem.Any())
        {
            return NotFound();
        }


    return Ok(montagem);




}
  
}


}