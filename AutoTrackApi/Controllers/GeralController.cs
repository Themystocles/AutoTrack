using AutoTrackApi.Interface;
using AutoTrackApi.Model;
using AutoTrackApi.Model.DTOs;
using AutoTrackApi.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace AutoTrack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GeralController : ControllerBase
    {
        private readonly IGeralPersist _geralPersist;

        public GeralController(IGeralPersist geralPersist)
        {
            _geralPersist = geralPersist;
        }

     
        [HttpGet("orcamentos")]
        public async Task<ActionResult<IEnumerable<Orcamento>>> GetOrcamento()
        {
            var Orcamento = await _geralPersist.GetAll<Orcamento>();
            return Ok(Orcamento);
        }
       

        
       



        [HttpPut("montagem/{id}")]
        public async Task<IActionResult> putmontagem(int id, [FromBody] MontagemDtos montagemDto)
        {
            if (id != montagemDto.Id)
            {
                return BadRequest("O Id da URL não corresponde ao Id do cliente.");
            }

            var montagemExistente = await _geralPersist.GetByIdAsync<Montagem>(id);
            if (montagemExistente == null)
            {
                return NotFound("Cliente não encontrado.");
            }

            // Mapear DTO para a entidade Montagem
            montagemExistente.data = montagemDto.Data;
            montagemExistente.GeracaoInstaladores = montagemDto.GeracaoInstaladores;
            montagemExistente.RedutorMarca = montagemDto.RedutorMarca;
            montagemExistente.NumeroSerie = montagemDto.NumeroSerie;
            montagemExistente.FormaPagamento = montagemDto.FormaPagamento;
            montagemExistente.pago = montagemDto.pago;
            montagemExistente.MarcaCilindro = montagemDto.MarcaCilindro;
            montagemExistente.NumeroCilindro = montagemDto.NumeroCilindro;
            montagemExistente.Quilo = montagemDto.Quilo;
            montagemExistente.Litro = montagemDto.Litro;
            montagemExistente.AnoFab = montagemDto.AnoFab;
           
            montagemExistente.AnoReteste = montagemDto.AnoReteste;
            montagemExistente.Requalificadora = montagemDto.Requalificadora;
            montagemExistente.NumeroNFEquipamento = montagemDto.NumeroNFEquipamento;
            montagemExistente.NumeroOrdemRequalificacao = montagemDto.NumeroOrdemRequalificacao;
            montagemExistente.NumeroLaudoMontagem = montagemDto.NumeroLaudoMontagem;
            montagemExistente.MarcaValvula = montagemDto.MarcaValvula;
            montagemExistente.NumeroNFServicoMontagem = montagemDto.NumeroNFServicoMontagem;
            montagemExistente.NumeroValvula = montagemDto.NumeroValvula;
            montagemExistente.Selo = montagemDto.Selo;
           
            
            montagemExistente.Instaladores = montagemDto.Instaladores;
            montagemExistente.ValorTotal = montagemDto.ValorTotal;
            montagemExistente.KitDaLoja = montagemDto.KitDaLoja;
            montagemExistente.ValorTotal = montagemDto.ValorTotal;

            // Atualizar orçamentos associados
            foreach (var orcamentoDto in montagemDto.Orcamentos)
    {
        var orcamentoExistente = await _geralPersist.GetByIdAsync<Orcamento>(orcamentoDto.Id);

        if (orcamentoExistente == null)
        {
            // Se o orçamento não existir, criá-lo
            var novoOrcamento = new Orcamento
            {
                Id = orcamentoDto.Id,
                Quantidade = orcamentoDto.Quantidade,
                NomeServico = orcamentoDto.NomeServico,
                Produto = orcamentoDto.Produto,
                ValorParcial = orcamentoDto.ValorParcial,
                ValorTotal = orcamentoDto.ValorTotal,
                ServicoId = orcamentoDto.ServicoId,
                EstoqueId = orcamentoDto.EstoqueId,
                MontagemId = orcamentoDto.MontagemId
            };
            await _geralPersist.Editar(novoOrcamento);
        }
        else
        {
            // Atualizar o orçamento existente
            orcamentoExistente.Quantidade = orcamentoDto.Quantidade;
            orcamentoExistente.NomeServico = orcamentoDto.NomeServico;
            orcamentoExistente.Produto = orcamentoDto.Produto;
            orcamentoExistente.ValorParcial = orcamentoDto.ValorParcial;
            orcamentoExistente.ValorTotal = orcamentoDto.ValorTotal;
            orcamentoExistente.EstoqueId = orcamentoDto.EstoqueId;
            orcamentoExistente.MontagemId = orcamentoDto.MontagemId;

            await _geralPersist.Editar(orcamentoExistente);
        }
    }


            await _geralPersist.Editar(montagemExistente);
            return Ok(montagemExistente);
        }

        // Rotas para Veículo
        [HttpGet("veiculos")]
        public async Task<ActionResult<IEnumerable<Veiculo>>> GetVeiculos()
        {
            var veiculos = await _geralPersist.GetAll<Veiculo>();
            return Ok(veiculos);
        }
        [HttpPost("Orcamento")]
public async Task<IActionResult> PostOrcamento([FromBody] OrcamentoDto orcamentoDto)
{
    if (orcamentoDto == null)
    {
        return BadRequest("Orçamento is null");
    }
    
    var orcamento = new Orcamento
    {
        Id = orcamentoDto.Id,
        Quantidade = orcamentoDto.Quantidade,
        NomeServico = orcamentoDto.NomeServico,
        Produto = orcamentoDto.Produto,
        ValorParcial = orcamentoDto.ValorParcial,
        ValorTotal = orcamentoDto.ValorTotal,
        KmAtual = orcamentoDto.KmAtual,
        ServicoId = orcamentoDto.ServicoId != 0 ? orcamentoDto.ServicoId : (int?)null,
        MontagemId = orcamentoDto.MontagemId != 0 ? orcamentoDto.MontagemId : (int?)null,
        EstoqueId = orcamentoDto.EstoqueId != 0 ? orcamentoDto.EstoqueId : (int?)null
    };

    await _geralPersist.AddAsync(orcamento);
    return CreatedAtAction(nameof(GetVeiculos), new { id = orcamento.Id }, orcamento);
}

       

    

       
        

        [HttpGet("montagem")]
        public async Task<ActionResult<IEnumerable<Montagem>>> GetMontagem()
        {
            var montagem = await _geralPersist.GetAll<Montagem>();
            return Ok(montagem);
        }
        [HttpPost("montagem")]
        public async Task<IActionResult> PostMontagem([FromBody] Montagem montagem)
        {
            if (montagem == null)
            {
                return BadRequest("Serviço is null");
            }

            await _geralPersist.AddAsync(montagem);
            return CreatedAtAction(nameof(GetMontagem), new { id = montagem.Id }, montagem);
        }
    }
}
