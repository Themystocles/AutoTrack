using AutoTrackApi.Interface;
using AutoTrackApi.Model;
using AutoTrackApi.Model.DTOs;
using AutoTrackApi.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoTrack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicoController : ControllerBase
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IServicoPersist _ServicoPersist;
        private readonly IEstoquePersist _EstoquePersist;

        public ServicoController(IGeralPersist geralPersist, IServicoPersist servicoPersist, IEstoquePersist EstoquePersist)
        {
            _geralPersist = geralPersist;
            _ServicoPersist = servicoPersist;
            _EstoquePersist = EstoquePersist;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Servico>>> GetServicos()
        {
            var servicos = await _geralPersist.GetAll<Servico>();
            return Ok(servicos);
        }


        [HttpGet("servico/{dataServ}")]
        public async Task<ActionResult<IEnumerable<Servico>>> GetServicosByDate(DateTime dataServ)
        {
            var servicos = await _ServicoPersist.GetServicosByDate(dataServ);

            if (servicos == null || !servicos.Any())
            {
                return NotFound();
            }

            return Ok(servicos);
        }
        [HttpGet("alertservico/{dataAlert}")]
        public async Task<ActionResult<IEnumerable<Servico>>> GetServicosByDateAlert(DateTime dataAlert)
        {
            var servicos = await _ServicoPersist.GetServicosByAlertDate(dataAlert);

            if (servicos == null || !servicos.Any())
            {
                return Ok(new List<Servico>());
            }

            return Ok(servicos);
        }
        [HttpGet("servico/tiposerv")]
        public async Task<ActionResult<IEnumerable<Servico>>> GetServicosByDate(string TipoServ)
        {
            var servicos = await _ServicoPersist.GetServicosByTipo(TipoServ);

            if (servicos == null || !servicos.Any())
            {
                return NotFound();
            }

            return Ok(servicos);
        }
        [HttpGet("idServico/{idServico}")]
        public async Task<ActionResult<IEnumerable<Servico>>> GetServicoById(int idServico)
        {
            var servicos = await _ServicoPersist.GetServicoById(idServico);

            if (servicos == null)
            {
                return NotFound();
            }

            return Ok(servicos);
        }
        [HttpGet("servicos/nao-pagos")]
        public async Task<IActionResult> GetCountServicosNaoPagos()
        {
            var count = await _ServicoPersist.GetCountServicosNaoPagos();
            return Ok(count);
        }
        [HttpGet("listServicos/nao-pagos")]
        public async Task<IActionResult> getServicosnãopagos()
        {
            var servicos = await _ServicoPersist.GetServicosNaoPagos();
            return Ok(servicos);
        }

        [HttpPost("servicos")]
        public async Task<IActionResult> PostServico([FromBody] Servico servico)
        {
            if (servico == null)
            {
                return BadRequest("Serviço is null");
            }


            await _geralPersist.AddAsync(servico);
            return CreatedAtAction(nameof(GetServicos), new { id = servico.Id }, servico);
        }
        [HttpPut("servico/{id}")]
        public async Task<IActionResult> PutServico(int id, [FromBody] ServicoDto servicoDto)
        {
            if (id != servicoDto.Id)
            {
                return BadRequest("O Id da URL não corresponde ao Id do serviço.");
            }

            var servicoExistente = await _geralPersist.GetByIdAsync<Servico>(id);
            if (servicoExistente == null)
            {
                return NotFound("Serviço não encontrado.");
            }

            // Atualizar o serviço
            servicoExistente.Descricao = servicoDto.Descricao;
            servicoExistente.pago = servicoDto.pago;
            servicoExistente.dataalerta = servicoDto.dataalerta;
            servicoExistente.FormaPag = servicoDto.FormaPag;
            servicoExistente.Mecanico = servicoDto.Mecanico;
            servicoExistente.Observacao = servicoDto.Observacao;
            servicoExistente.DataServico = servicoDto.DataServico;
            servicoExistente.Totalorcamento = servicoDto.Totalorcamento;
            servicoExistente.Status = servicoDto.Status;
            servicoExistente.Requalificacao = servicoDto.Requalificacao;
            servicoExistente.MarcaCilindro = servicoDto.MarcaCilindro;
            servicoExistente.NumeroCilindro = servicoDto.NumeroCilindro;
            servicoExistente.Requalificadora = servicoDto.Requalificadora;
            servicoExistente.Ordem = servicoDto.Ordem;
            servicoExistente.NotaDeServico = servicoDto.NotaDeServico;
            servicoExistente.Laudo = servicoDto.Laudo;
            servicoExistente.NotaDaValvula = servicoDto.NotaDaValvula;
            servicoExistente.MarcaValvula = servicoDto.MarcaValvula;
            servicoExistente.NumeroValvula = servicoDto.NumeroValvula;

            // Atualizar orçamentos associados
            decimal somaValorTotalorc = 0;
            int quantidadeEstoque = 0;
            foreach (var orcamentoDto in servicoDto.Orcamentos)
            {
                var orcamentoExistente = await _geralPersist.GetByIdAsync<Orcamento>(orcamentoDto.Id);

                if (orcamentoExistente == null)
                {
                    // Se o orçamento não existir, criá-lo
                    var novoOrcamento = new Orcamento
                    {
                        Id = orcamentoDto.Id,
                        DataOrc = orcamentoDto.DataOrc,
                        Quantidade = orcamentoDto.Quantidade,
                        NomeServico = orcamentoDto.NomeServico,
                        Produto = orcamentoDto.Produto,
                        ValorParcial = orcamentoDto.ValorParcial,
                        ValorTotal = orcamentoDto.ValorTotal,
                        Garantia = orcamentoDto.Garantia,
                        KmAtual = orcamentoDto.KmAtual,
                        ServicoId = orcamentoDto.ServicoId,
                        EstoqueId = orcamentoDto.EstoqueId,
                        MontagemId = orcamentoDto.MontagemId
                    };
                    await _geralPersist.Editar(novoOrcamento);

                    somaValorTotalorc += novoOrcamento.ValorTotal;
                    quantidadeEstoque += novoOrcamento.Quantidade;

                    // Atualizar o estoque após criar o orçamento
                    // await _EstoquePersist.AtualizarEstoqueExistenteAsync(novoOrcamento.NomeServico, novoOrcamento.Quantidade);
                }
                else
                {
                    // Atualizar o estoque após editar o orçamento
                    if (orcamentoDto.Quantidade != orcamentoExistente.Quantidade)
                    {
                        int Diferenca = orcamentoDto.Quantidade - orcamentoExistente.Quantidade;
                        await _EstoquePersist.AtualizarEstoqueExistenteAsync(orcamentoDto.NomeServico, Diferenca);
                    }
                    // Atualizar o orçamento existente
                    orcamentoExistente.Quantidade = orcamentoDto.Quantidade;
                    orcamentoExistente.NomeServico = orcamentoDto.NomeServico;
                    orcamentoExistente.Produto = orcamentoDto.Produto;
                    orcamentoExistente.KmAtual = orcamentoDto.KmAtual;
                    orcamentoExistente.ValorParcial = orcamentoDto.ValorParcial;
                    orcamentoExistente.ValorTotal = orcamentoDto.ValorTotal;
                    orcamentoExistente.Garantia = orcamentoDto.Garantia;
                    orcamentoExistente.EstoqueId = orcamentoDto.EstoqueId;
                    orcamentoExistente.MontagemId = orcamentoDto.MontagemId;

                    await _geralPersist.Editar(orcamentoExistente);
                    somaValorTotalorc += orcamentoExistente.ValorTotal;
                    quantidadeEstoque += orcamentoExistente.Quantidade;



                }
            }

            servicoExistente.Totalorcamento = somaValorTotalorc;
            await _geralPersist.Editar(servicoExistente);

            return Ok(servicoExistente);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServico(int id)
        {
            var deleteServico = await _ServicoPersist.DeleteServico(id);
            if (deleteServico == null)
            {
                return NotFound(); // Retorna 404 se não encontrar
            }

            return Ok(deleteServico); // Retorna 200 com o orçamento excluído
        }
        [HttpGet("servicos/{status}")]
        public async Task<IActionResult> GetServicosByStatus(string status)
        {
            var servico = await _ServicoPersist.GetServicosByStatus(status);
            return Ok(servico);
        }

    }




}
