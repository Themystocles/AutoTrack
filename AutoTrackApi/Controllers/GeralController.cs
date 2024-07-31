using AutoTrackApi.Interface;
using AutoTrackApi.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoTrack.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GeralController : ControllerBase
    {
        private readonly IGeralPersist _geralPersist;

        public GeralController(IGeralPersist geralPersist)
        {
            _geralPersist = geralPersist;
        }

        // Rotas para Cliente
        [HttpGet("clientes")]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            var clientes = await _geralPersist.GetAll<Cliente>();
            return Ok(clientes);
        }

        [HttpPost("clientes")]
        public async Task<IActionResult> PostCliente([FromBody] Cliente cliente)
        {
            if (cliente == null)
            {
                return BadRequest("Cliente is null");
            }

            await _geralPersist.AddAsync(cliente);
            return CreatedAtAction(nameof(GetClientes), new { id = cliente.Id }, cliente);
        }

        // Rotas para Veículo
        [HttpGet("veiculos")]
        public async Task<ActionResult<IEnumerable<Veiculo>>> GetVeiculos()
        {
            var veiculos = await _geralPersist.GetAll<Veiculo>();
            return Ok(veiculos);
        }

        [HttpPost("veiculos")]
        public async Task<IActionResult> PostVeiculo([FromBody] Veiculo veiculo)
        {
            if (veiculo == null)
            {
                return BadRequest("Veículo is null");
            }

            await _geralPersist.AddAsync(veiculo);
            return CreatedAtAction(nameof(GetVeiculos), new { id = veiculo.Id }, veiculo);
        }
    
     [HttpGet("servicos")]
        public async Task<ActionResult<IEnumerable<Veiculo>>> GetServicos()
        {
            var servicos = await _geralPersist.GetAll<Servico>();
            return Ok(servicos);
        }

        [HttpPost("servicos")]
        public async Task<IActionResult> PostServico([FromBody] Servico servico)
        {
            if (servico == null)
            {
                return BadRequest("Veículo is null");
            }

            await _geralPersist.AddAsync(servico);
            return CreatedAtAction(nameof(GetVeiculos), new { id = servico.Id }, servico);
        }
    }
}
