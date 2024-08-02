using AutoTrackApi.Interface;
using AutoTrackApi.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoTrack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VeiculoController : ControllerBase
    {
        private readonly IGeralPersist _geralPersist;

        public VeiculoController(IGeralPersist geralPersist)
        {
            _geralPersist = geralPersist;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Veiculo>>> GetVeiculos()
        {
            var veiculos = await _geralPersist.GetAll<Veiculo>();
            return Ok(veiculos);
        }

        [HttpPost]
        public async Task<IActionResult> PostVeiculo([FromBody] Veiculo veiculo)
        {
            if (veiculo == null)
            {
                return BadRequest("Veículo is null");
            }

            await _geralPersist.AddAsync(veiculo);
            return CreatedAtAction(nameof(GetVeiculos), new { id = veiculo.Id }, veiculo);
        }
    }
}
