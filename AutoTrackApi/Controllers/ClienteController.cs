using AutoTrackApi.Interface;
using AutoTrackApi.Model;
using AutoTrackApi.Model.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
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
        [HttpGet("id/{id}")]
        public async Task<ActionResult<Cliente>> GetClienteByID(int id)
        {
            var cliente = await _clientePersist.GetClienteByID(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
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

         [HttpPost("clientes")]
        public async Task<IActionResult> PostCliente([FromBody] ClienteDto clienteDto)
        {
            if (clienteDto == null)
            {
                return BadRequest("Cliente is null");
            }
            try{
            var Cliente = new Cliente
            {
                Nome = clienteDto.Nome,
                Cpf = clienteDto.Cpf,
                InsEstadual = clienteDto.InsEstadual,
                InsMunicipal = clienteDto.InsMunicipal,
                Telefone = clienteDto.Telefone,
                InsTelefone2 = clienteDto.InsTelefone2,
                Endereco = clienteDto.Endereco,
                Bairro = clienteDto.Bairro,
                Cidade = clienteDto.Cidade,
                Cep = clienteDto.Cep,
                Uf = clienteDto.Uf

            };

            await _geralPersist.AddAsync(Cliente);
            return CreatedAtAction(nameof(GetClientes), new { id = Cliente.Id }, Cliente);

            }
            catch(DbUpdateException ex){
                if (ex.InnerException is SqliteException sqliteEx && sqliteEx.SqliteErrorCode == 19)
        {
            return BadRequest("O CPF informado já está cadastrado.");
        }
         return StatusCode(500, "Ocorreu um erro ao salvar os dados.");
            }   
        }

        [HttpPut("cliente/{id}")]
        public async Task<IActionResult> PutCliente(int id, [FromBody] ClienteDto clienteDto)
        {
            if (id != clienteDto.Id)
            {
                return BadRequest("O Id da URL não corresponde ao Id do cliente.");
            }

            var clienteExistente = await _geralPersist.GetByIdAsync<Cliente>(id);
            if (clienteExistente == null)
            {
                return NotFound("Cliente não encontrado.");
            }

            // Mapear DTO para a entidade Cliente
            clienteExistente.Nome = clienteDto.Nome;
            clienteExistente.Cpf = clienteDto.Cpf;
            clienteExistente.InsEstadual = clienteDto.InsEstadual;
            clienteExistente.InsMunicipal = clienteDto.InsMunicipal;
            clienteExistente.Telefone = clienteDto.Telefone;
            clienteExistente.InsTelefone2 = clienteDto.InsTelefone2;
            clienteExistente.Endereco = clienteDto.Endereco;
            clienteExistente.Bairro = clienteDto.Bairro;
            clienteExistente.Cidade = clienteDto.Cidade;
            clienteExistente.Cep = clienteDto.Cep;
            clienteExistente.Uf = clienteDto.Uf;

            await _geralPersist.Editar(clienteExistente);
            return Ok(clienteExistente);
        }


    }
}
