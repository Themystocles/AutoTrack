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
        [HttpGet("telefone/{telefone}")]
        public async Task<ActionResult<Cliente>> GetClienteByTelefone(string telefone)
        {
            var cliente = await _clientePersist.GetClienteBynumeroTel(telefone);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }
        [HttpGet("nome/{nome}")]
        public async Task<ActionResult<Cliente>> GetClienteByNome(string nome)
        {
            var cliente = await _clientePersist.GetClientesByNome(nome);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }


       }
}
