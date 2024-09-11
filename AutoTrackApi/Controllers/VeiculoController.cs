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
        

        public VeiculoController(IGeralPersist geralPersist,IVeiculoPersist veiculoPersist )
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
            try{
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

            } catch(DbUpdateException ex){
                if (ex.InnerException is SqliteException sqliteEx && sqliteEx.SqliteErrorCode == 19)
        {
            return BadRequest("Atenção: a placa ou o chassi já estão cadastrados no sistema.");
        }
         return StatusCode(500, "Ocorreu um erro ao salvar os dados.");
            }   
        
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
