using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoTrackApi.DataContext;
using AutoTrackApi.Interface;
using AutoTrackApi.Model;
using AutoTrackApi.Model.DTOs;
using AutoTrackApi.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AutoTrackApi.Controllers
{
    [Route("[controller]")]
    public class OrcamentoController : ControllerBase
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IEstoquePersist _estoquepersist;
        public readonly ConnectionContext _context;

        public readonly IOrcamentoPersist _orcamentoPersist;

        public OrcamentoController(IGeralPersist geralPersist, IEstoquePersist estoquePersist, ConnectionContext context, IOrcamentoPersist orcamentoPersist)
        {
            _geralPersist = geralPersist;
            _estoquepersist = estoquePersist;
            _context = context;
            _orcamentoPersist = orcamentoPersist;
        }

         [HttpGet("orcamentos")]
        public async Task<ActionResult<IEnumerable<Orcamento>>> GetOrcamento()
        {
            var Orcamento = await _orcamentoPersist.getAllorc();
            

            return Ok(Orcamento);
        }
         // Rotas para Veículo
        [HttpGet("veiculos")]
        public async Task<ActionResult<IEnumerable<Veiculo>>> GetVeiculos()
        {
            var veiculos = await _geralPersist.GetAll<Veiculo>();
            return Ok(veiculos);
        }
[HttpGet("orcamentos/{id}/funcionarios")]
public async Task<IActionResult> GetFuncionariosPorOrcamento(int id)
{
    var funcionarios = await _context.OrcamentoFuncionarios
        .Where(of => of.OrcamentoId == id)
        .Include(of => of.Funcionario) // Supondo que você tenha uma relação com Funcionario
        .Select(of => new 
        {
            of.FuncionarioId,
            of.Funcionario.Nome // Supondo que Funcionario tenha um campo Nome
        })
        .ToListAsync();

    return Ok(funcionarios);
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
        Garantia = orcamentoDto.Garantia,
        DataOrc = orcamentoDto.DataOrc,
        KmAtual = orcamentoDto.KmAtual,
        ServicoId = orcamentoDto.ServicoId != 0 ? orcamentoDto.ServicoId : (int?)null,
        MontagemId = orcamentoDto.MontagemId != 0 ? orcamentoDto.MontagemId : (int?)null,
        EstoqueId = orcamentoDto.EstoqueId != 0 ? orcamentoDto.EstoqueId : (int?)null
    };
// Adicionar a lista de OrcamentoFuncionario
    if (orcamentoDto.FuncionariosIds != null)
    {
        orcamento.OrcamentoFuncionarios = orcamentoDto.FuncionariosIds.Select(funcionarioId => new OrcamentoFuncionario
        {
            OrcamentoId = orcamento.Id,
            FuncionarioId = funcionarioId
            
        }).ToList();
    }
    
    

    await _geralPersist.AddAsync(orcamento);
    await _estoquepersist.AtualizarEstoqueAsync(orcamento.NomeServico, orcamento.Quantidade);
    
    return CreatedAtAction(nameof(GetVeiculos), new { id = orcamento.Id }, orcamento);
}

[HttpDelete("{id}")]
public async Task<IActionResult> DeleteOrcamento(int id)
{
    var deletedOrcamento = await _orcamentoPersist.Delete(id);
    if (deletedOrcamento == null)
    {
        return NotFound(); // Retorna 404 se não encontrar
    }

    return Ok(deletedOrcamento); // Retorna 200 com o orçamento excluído
}
       

      

        
    }
}