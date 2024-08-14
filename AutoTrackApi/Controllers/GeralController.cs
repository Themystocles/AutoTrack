using AutoTrackApi.Interface;
using AutoTrackApi.Model;
using AutoTrackApi.Model.DTOs;
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

        [HttpPost("clientes")]
        public async Task<IActionResult> PostCliente([FromBody] Cliente cliente)
        {
            if (cliente == null)
            {
                return BadRequest("Cliente is null");
            }

            await _geralPersist.AddAsync(cliente);
            return CreatedAtAction(nameof(GetClientes), new { id = cliente.Id }, cliente);
        }

        [HttpPut("cliente/{id}")]
        public async Task<IActionResult> PutCliente(int id, [FromBody] ClienteCreateDto clienteDto)
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
        public async Task<IActionResult> putservico(int id, [FromBody] ServicoDto servicoDto)
        {
            if (id != servicoDto.Id)
            {
                return BadRequest("O Id da URL não corresponde ao Id do cliente.");
            }

            var servicoExistente = await _geralPersist.GetByIdAsync<Servico>(id);
            if (servicoExistente == null)
            {
                return NotFound("Cliente não encontrado.");
            }

     // Mapear DTO para a entidade Servico
    servicoExistente.Descricao = servicoDto.Descricao;
    servicoExistente.Quantidade = servicoDto.Quantidade;
    servicoExistente.Peca_Servico = servicoDto.PecaServico;
    servicoExistente.ValorUni = servicoDto.ValorUni;
    servicoExistente.ValorTot = servicoDto.ValorTot;
    servicoExistente.FormaPag = servicoDto.FormaPag;
    servicoExistente.Mecanico = servicoDto.Mecanico;
    servicoExistente.Saida = servicoDto.Saida;
    servicoExistente.DataServico = servicoDto.DataServico;

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

        [HttpPost("veiculos")]
        public async Task<IActionResult> PostVeiculo([FromBody] Veiculo veiculo)
        {
            if (veiculo == null)
            {
                return BadRequest("Veículo is null");
            }

            await _geralPersist.AddAsync(veiculo);
            return CreatedAtAction(nameof(GetVeiculos), new { id = veiculo.Id }, veiculo);
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
