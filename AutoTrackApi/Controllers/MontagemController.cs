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

    [HttpPost]
    public async Task<IActionResult> PostMontagem([FromBody] Montagem montagem)
    {
        if (montagem == null)
        {
            return BadRequest("Serviço is null");
        }

        await _geralPersist.AddAsync(montagem);
        return CreatedAtAction(nameof(GetMontagem), new { id = montagem.Id }, montagem);
    }

    [HttpGet("montagem/{datamont}")]
    public async Task<ActionResult<IEnumerable<Montagem>>> GetMontbyData(string dataMont)
    {
        var montagem = await _MontagemPersist.GetMontagemsByData(dataMont);

        if (montagem == null || !montagem.Any())
        {
            return NotFound();
        }

        return Ok(montagem);
    }
}

}