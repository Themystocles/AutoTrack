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

        public ServicoController(IGeralPersist geralPersist)
        {
            _geralPersist = geralPersist;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Servico>>> GetServicos()
        {
            var servicos = await _geralPersist.GetAll<Servico>();
            return Ok(servicos);
        }

        [HttpPost]
        public async Task<IActionResult> PostServico([FromBody] Servico servico)
        {
            if (servico == null)
            {
                return BadRequest("Serviço is null");
            }

            await _geralPersist.AddAsync(servico);
            return CreatedAtAction(nameof(GetServicos), new { id = servico.Id }, servico);
        }
    }
}
