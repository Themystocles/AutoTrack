using AutoTrackApi.Interface;
using AutoTrackApi.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoTrack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IClientePersist _clientePersist;

        public ClienteController(IGeralPersist geralPersist, IClientePersist clientePersist)
        {
            _geralPersist = geralPersist;
            _clientePersist = clientePersist;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            var clientes = await _geralPersist.GetAll<Cliente>();
            return Ok(clientes);
        }

        [HttpGet("{cpf}")]
        public async Task<ActionResult<Cliente>> GetClienteByCpf(string cpf)
        {
            var cliente = await _clientePersist.GetClienteByCpf(cpf);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> PostCliente([FromBody] Cliente cliente)
        {
            if (cliente == null)
            {
                return BadRequest("Cliente is null");
            }

            await _geralPersist.AddAsync(cliente);
            return CreatedAtAction(nameof(GetClientes), new { id = cliente.Id }, cliente);
        }
    }
}
