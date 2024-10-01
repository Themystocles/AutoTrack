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
    public class VeiculoController : ControllerBase
    {
        private readonly IGeralPersist _geralPersist;

        private readonly IVeiculoPersist _veiculoPersist;


        public VeiculoController(IGeralPersist geralPersist, IVeiculoPersist veiculoPersist)
        {
            _geralPersist = geralPersist;
            _veiculoPersist = veiculoPersist;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Veiculo>>> GetVeiculos()
        {
            var veiculos = await _geralPersist.GetAll<Veiculo>();
            return Ok(veiculos);
        }


        [HttpGet("veiculo/{placa}")]
        public async Task<ActionResult<IEnumerable<Veiculo>>> getVeiculoByPlaca(string placa)
        {
            var veiculo = await _veiculoPersist.GetVeiculoByPlaca(placa);
            if (veiculo == null)
            {
                return NotFound();
            }
            return Ok(veiculo);
        }
        [HttpGet("chassi/{chassi}")]
        public async Task<ActionResult<IEnumerable<Veiculo>>> getVeiculoByChassi(string chassi)
        {
            var veiculo = await _veiculoPersist.GetVeiculoByChassi(chassi);
            if (veiculo == null)
            {
                return NotFound();
            }
            return Ok(veiculo);
        }
        [HttpGet("id/{id}")]
        public async Task<ActionResult<Veiculo>> GetVeiculoById(int id)
        {
            var veiculo = await _veiculoPersist.GetVeiculoByID(id);
            if (veiculo == null)
            {
                return NotFound();
            }
            return Ok(veiculo);
        }
        [HttpPost("veiculos")]
        public async Task<IActionResult> PostVeiculo([FromBody] VeiculoPostDto veiculoPostDto)
        {
            if (veiculoPostDto == null)
            {
                return BadRequest("Veículo is null");
            }
            if (await _veiculoPersist.VeiculoplacaoExistsAsync(veiculoPostDto.Placa))
            {
                return Conflict("Já Existe um veículo com essa placa");

            }
            if (await _veiculoPersist.VeiculochassiExistsAsync(veiculoPostDto.Chassi))
            {
                return Conflict("Já existe um veículo com esse Chassi.");

            }



            var Veiculo = new Veiculo
            {

                Carro = veiculoPostDto.Carro,
                Placa = veiculoPostDto.Placa,
                Especie = veiculoPostDto.Especie,
                Combustivel = veiculoPostDto.Combustivel,
                Potencia = veiculoPostDto.Potencia,
                AnoFab = veiculoPostDto.AnoFab,
                Capacidade = veiculoPostDto.Capacidade,
                AnoModelo = veiculoPostDto.AnoModelo,
                Chassi = veiculoPostDto.Chassi,
                Cor = veiculoPostDto.Cor,
                Observacao = veiculoPostDto.Observacao,

                Renavam = veiculoPostDto.Renavam,
                ClienteId = veiculoPostDto.ClienteId

            };

            await _geralPersist.AddAsync(Veiculo);
            return CreatedAtAction(nameof(GetVeiculos), new { id = Veiculo.Id }, Veiculo);



        }
        [HttpPut("veiculo/{id}")]
        public async Task<IActionResult> putveiculo(int id, [FromBody] VeiculoDto veiculoDto)
        {
            if (id != veiculoDto.Id)
            {
                return BadRequest("O Id da URL não corresponde ao Id do cliente.");
            }

            var veiculoExistente = await _geralPersist.GetByIdAsync<Veiculo>(id);
            if (veiculoExistente == null)
            {
                return NotFound("Veículo não encontrado.");
            }

            // Mapear DTO para a entidade Veiculo
            veiculoExistente.Carro = veiculoDto.Carro;
            veiculoExistente.Placa = veiculoDto.Placa;
            veiculoExistente.Especie = veiculoDto.Especie;
            veiculoExistente.Combustivel = veiculoDto.Combustivel;
            veiculoExistente.Potencia = veiculoDto.Potencia;
            veiculoExistente.AnoFab = veiculoDto.AnoFab;
            veiculoExistente.Capacidade = veiculoDto.Capacidade;
            veiculoExistente.AnoModelo = veiculoDto.AnoModelo;
            veiculoExistente.Chassi = veiculoDto.Chassi;
            veiculoExistente.Cor = veiculoDto.Cor;
            veiculoExistente.Observacao = veiculoDto.Observacao;

            veiculoExistente.Renavam = veiculoDto.Renavam;

            await _geralPersist.Editar(veiculoExistente);
            return Ok(veiculoExistente);
        }
    }
}
