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
    public class GeralController : ControllerBase
    {
        private readonly IGeralPersist _geralPersist;

        public GeralController(IGeralPersist geralPersist)
        {
            _geralPersist = geralPersist;
        }

        // Rotas para Cliente
        [HttpGet("clientes")]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            var clientes = await _geralPersist.GetAll<Cliente>();
            return Ok(clientes);
        }
        [HttpGet("orcamentos")]
        public async Task<ActionResult<IEnumerable<Orcamento>>> GetOrcamento()
        {
            var Orcamento = await _geralPersist.GetAll<Orcamento>();
            return Ok(Orcamento);
        }
       

        [HttpPost("clientes")]
        public async Task<IActionResult> PostCliente([FromBody] ClienteDto clienteDto)
        {
            if (clienteDto == null)
            {
                return BadRequest("Cliente is null");
            }
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
                return NotFound("Cliente não encontrado.");
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
            veiculoExistente.KmAtual = veiculoDto.KmAtual;
            veiculoExistente.ProxManutencao = veiculoDto.ProxManutencao;
            veiculoExistente.ProxTrocaFiltro = veiculoDto.ProxTrocaFiltro;
            veiculoExistente.Garantia = veiculoDto.Garantia;
            veiculoExistente.Renavam = veiculoDto.Renavam;

            await _geralPersist.Editar(veiculoExistente);
            return Ok(veiculoExistente);
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
    
    servicoExistente.FormaPag = servicoDto.FormaPag;
    servicoExistente.Mecanico = servicoDto.Mecanico;
    servicoExistente.Observacao = servicoDto.Observacao;
    servicoExistente.DataServico = servicoDto.DataServico;

    // Atualizar orçamentos associados
    foreach (var orcamentoDto in servicoDto.Orcamentos)
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

    await _geralPersist.Editar(servicoExistente);

    return Ok(servicoExistente);
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
            montagemExistente.RedutorValor = montagemDto.RedutorValor;
            montagemExistente.NumeroSerie = montagemDto.NumeroSerie;
            montagemExistente.FormaPagamento = montagemDto.FormaPagamento;
            montagemExistente.MarcaCilindro = montagemDto.MarcaCilindro;
            montagemExistente.NumeroCilindro = montagemDto.NumeroCilindro;
            montagemExistente.Quilo = montagemDto.Quilo;
            montagemExistente.Litro = montagemDto.Litro;
            montagemExistente.AnoFab = montagemDto.AnoFab;
            montagemExistente.DocumentacaoAno = montagemDto.DocumentacaoAno;
            montagemExistente.AnoReteste = montagemDto.AnoReteste;
            montagemExistente.Requalificadora = montagemDto.Requalificadora;
            montagemExistente.NumeroNFEquipamento = montagemDto.NumeroNFEquipamento;
            montagemExistente.NumeroOrdemRequalificacao = montagemDto.NumeroOrdemRequalificacao;
            montagemExistente.NumeroLaudoMontagem = montagemDto.NumeroLaudoMontagem;
            montagemExistente.MarcaValvula = montagemDto.MarcaValvula;
            montagemExistente.NumeroNFServicoMontagem = montagemDto.NumeroNFServicoMontagem;
            montagemExistente.NumeroValvula = montagemDto.NumeroValvula;
            montagemExistente.Selo = montagemDto.Selo;
            montagemExistente.Orcamento = montagemDto.Orcamento;
            montagemExistente.QuantPecaServico = montagemDto.QuantPecaServico;
            montagemExistente.ValorUnitario = montagemDto.ValorUnitario;
            montagemExistente.ValorTotal = montagemDto.ValorTotal;
            montagemExistente.KitDaLoja = montagemDto.KitDaLoja;

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
        ServicoId = orcamentoDto.ServicoId != 0 ? orcamentoDto.ServicoId : (int?)null,
        MontagemId = orcamentoDto.MontagemId != 0 ? orcamentoDto.MontagemId : (int?)null,
        EstoqueId = orcamentoDto.EstoqueId != 0 ? orcamentoDto.EstoqueId : (int?)null
    };

    await _geralPersist.AddAsync(orcamento);
    return CreatedAtAction(nameof(GetVeiculos), new { id = orcamento.Id }, orcamento);
}

        [HttpPost("veiculos")]
        public async Task<IActionResult> PostVeiculo([FromBody] VeiculoPostDto veiculoPostDto)
        {
            if (veiculoPostDto == null)
            {
                return BadRequest("Veículo is null");
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
                KmAtual = veiculoPostDto.KmAtual,
                ProxManutencao = veiculoPostDto.ProxManutencao,
                ProxTrocaFiltro = veiculoPostDto.ProxTrocaFiltro,
                Garantia = veiculoPostDto.Garantia,
                Renavam = veiculoPostDto.Renavam,
                ClienteId = veiculoPostDto.ClienteId
                
            };

            await _geralPersist.AddAsync(Veiculo);
            return CreatedAtAction(nameof(GetVeiculos), new { id = Veiculo.Id }, Veiculo);
        }

        [HttpGet("servicos")]
        public async Task<ActionResult<IEnumerable<Servico>>> GetServicos()
        {
            var servicos = await _geralPersist.GetAll<Servico>();
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
