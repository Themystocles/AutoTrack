using AutoTrackApi.Interface;
using AutoTrackApi.Model;
using AutoTrackApi.Model.DTOs;
using AutoTrackApi.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoTrackApi.Controllers
{
    [Route("api/[controller]")]
    public class MontagemController : ControllerBase
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IMontagemPersist _MontagemPersist;

         public MontagemController(IGeralPersist geralPersist, IMontagemPersist montagemPersist)
    {
        _geralPersist = geralPersist;
        _MontagemPersist = montagemPersist;
    }

   [HttpGet]
    public async Task<ActionResult<IEnumerable<Montagem>>> GetMontagem()
    {
        var montagem = await _geralPersist.GetAll<Montagem>();
        return Ok(montagem);
    }

   

    [HttpGet("montagem/{datamont}")]
    public async Task<ActionResult<IEnumerable<Montagem>>> GetMontbyData(DateTime dataMont)
    {
        var montagem = await _MontagemPersist.GetMontagemsByData(dataMont);

        if (montagem == null || !montagem.Any())
        {
            return NotFound();
        }

        return Ok(montagem);
    }
       [HttpGet("idmontagem/{idMontagem}")]
    public async Task<ActionResult<IEnumerable<Montagem>>> GetServicoById(int idMontagem)
    {
        var Montagem = await _MontagemPersist.GetMontagemById(idMontagem);

        if (Montagem == null)
        {
            return NotFound();
        }

        return Ok(Montagem);
    }

    [HttpGet("montagem/nao-pagos")]
public async Task<IActionResult> GetCountServicosNaoPagos()
{
    var count = await _MontagemPersist.GetCountMontagensNaoPagos();
    return Ok(count);
}
[HttpGet("listMontagens/nao-pagos")]
public async Task<IActionResult> getServicosnãopagos()
{
    var montagem = await _MontagemPersist.GetMontagensNaoPagos();
    return Ok(montagem);
}

[HttpGet("montagem/nfvendas")]
public async Task<ActionResult <IEnumerable<Montagem>>> GetMontagembyNfeVendas(string NFEVenda){

    var montagem = await _MontagemPersist.GetMontagensByNFEVenda(NFEVenda);

       if (montagem == null )
        {
            return NotFound();
        }


    return Ok(montagem);




}
    [HttpGet("alertmontagem/{dataAlert}")]
    public async Task<ActionResult<IEnumerable<Montagem>>> GetMontagemByDateAlert(DateTime dataAlert)
    {
        var montagem = await _MontagemPersist.GetMontagemByDataAlerta(dataAlert);

        if (montagem == null || !montagem.Any())
        {
            return Ok(new List<Montagem>());
        }

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

        

        [HttpPut("montagem/{id}")]
        public async Task<IActionResult> putmontagem(int id, [FromBody] MontagemDtos montagemDto)
        {
            if (id != montagemDto.Id)
            {
                return BadRequest("O Id da URL não corresponde ao Id da Montagem.");
            }

            var montagemExistente = await _geralPersist.GetByIdAsync<Montagem>(id);
            if (montagemExistente == null)
            {
                return NotFound("montagem não encontrada.");
            }

            // Mapear DTO para a entidade Montagem
            montagemExistente.data = montagemDto.Data;
            montagemExistente.dataalerta = montagemDto.dataalerta;
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
            decimal somaValorTotalorc = 0;
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
                KmAtual = orcamentoDto.KmAtual,
                ValorParcial = orcamentoDto.ValorParcial,
                ValorTotal = orcamentoDto.ValorTotal,
                ServicoId = orcamentoDto.ServicoId,
                EstoqueId = orcamentoDto.EstoqueId,
                MontagemId = orcamentoDto.MontagemId
            };
            await _geralPersist.Editar(novoOrcamento);
            somaValorTotalorc += novoOrcamento.ValorTotal;
        }
        else
        {
            // Atualizar o orçamento existente
            orcamentoExistente.Quantidade = orcamentoDto.Quantidade;
            orcamentoExistente.NomeServico = orcamentoDto.NomeServico;
            orcamentoExistente.Produto = orcamentoDto.Produto;
            orcamentoExistente.KmAtual = orcamentoDto.KmAtual;
            orcamentoExistente.ValorParcial = orcamentoDto.ValorParcial;
            orcamentoExistente.ValorTotal = orcamentoDto.ValorTotal;
            orcamentoExistente.EstoqueId = orcamentoDto.EstoqueId;
            orcamentoExistente.MontagemId = orcamentoDto.MontagemId;

            await _geralPersist.Editar(orcamentoExistente);

             somaValorTotalorc += orcamentoExistente.ValorTotal;


        }
         
    }

              montagemExistente.ValorTotal = somaValorTotalorc;
            await _geralPersist.Editar(montagemExistente);
            return Ok(montagemExistente);
        }

       
   
    

       
        

      
      
  
}


}