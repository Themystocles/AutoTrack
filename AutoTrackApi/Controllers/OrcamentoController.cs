using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoTrackApi.Interface;
using AutoTrackApi.Model;
using AutoTrackApi.Model.DTOs;
using AutoTrackApi.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AutoTrackApi.Controllers
{
    [Route("[controller]")]
    public class OrcamentoController : ControllerBase
    {
        private readonly IGeralPersist _geralPersist;

        public OrcamentoController(IGeralPersist geralPersist)
        {
            _geralPersist = geralPersist;
        }

         [HttpGet("orcamentos")]
        public async Task<ActionResult<IEnumerable<Orcamento>>> GetOrcamento()
        {
            var Orcamento = await _geralPersist.GetAll<Orcamento>();
            return Ok(Orcamento);
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


       

      

        
    }
}