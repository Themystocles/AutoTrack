using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoTrack.Migrations;
using AutoTrackApi.DataContext;
using AutoTrackApi.Interface;
using AutoTrackApi.Model.Entities;
using AutoTrackApi.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AutoTrackApi.Controllers
{
    [Route("[controller]")]
    public class FuncionarioController : ControllerBase
    {
        private readonly IGeralPersist _geralPersist;

        public FuncionarioController(IGeralPersist geralPersist)
        {
          _geralPersist = geralPersist;
        }

        [HttpGet("Funcionario")]
        public async Task<ActionResult<IEnumerable<Funcionarios>>> GetFuncionario()
        {
            var funcionario = await _geralPersist.GetAll<Funcionarios>();
            return Ok(funcionario);
        }
         [HttpGet("Funcionario/{id}")]
        public async Task<ActionResult<Funcionarios>> GetFuncionariobyId(int id)
        {
            var funcionario = await _geralPersist.GetByIdAsync<Funcionarios>(id);
            return Ok(funcionario);
        }

        [HttpPost("CadastroFuncionario")]
        public async Task<ActionResult<Funcionarios>> PostFuncionario([FromBody] Funcionarios funcionario)
        {
                if (funcionario == null)
    {
        return BadRequest("Funcionário não pode ser nulo.");
    }
  
            await _geralPersist.AddAsync(funcionario);
             
            return Ok(funcionario);
        }


[HttpPut("FuncionarioPut/{id}")]
public async Task<IActionResult> Putfuncionario(int id, [FromBody] Funcionarios funcionarios)
{
    // Valida se o modelo é válido
    if (!ModelState.IsValid)
    {
        return BadRequest(ModelState);
    }

    // Verifica se o ID da URL corresponde ao do corpo da requisição
    if (id != funcionarios.id)
    {
        return BadRequest("O Id da URL não corresponde ao Id do funcionário.");
    }

    // Busca o funcionário existente pelo ID
    var FuncionarioExistente = await _geralPersist.GetByIdAsync<Funcionarios>(id);
    if (FuncionarioExistente == null)
    {
        return NotFound("Funcionário não encontrado.");
    }

    // Atualiza as propriedades do funcionário
   FuncionarioExistente.Nome = funcionarios.Nome;
FuncionarioExistente.Cpf = funcionarios.Cpf;
FuncionarioExistente.DataAdmissao = funcionarios.DataAdmissao;
FuncionarioExistente.DataDemissao = funcionarios.DataDemissao;
FuncionarioExistente.Situacao = funcionarios.Situacao;
FuncionarioExistente.DataFerias = funcionarios.DataFerias;
FuncionarioExistente.Funcao = funcionarios.Funcao;
FuncionarioExistente.DataNascimento = funcionarios.DataNascimento;
FuncionarioExistente.Celular1 = funcionarios.Celular1;
FuncionarioExistente.Celular2 = funcionarios.Celular2;
FuncionarioExistente.Rua = funcionarios.Rua;
FuncionarioExistente.Cep = funcionarios.Cep;
FuncionarioExistente.Cidade = funcionarios.Cidade;
FuncionarioExistente.Bairro = funcionarios.Bairro;
FuncionarioExistente.Foto = funcionarios.Foto;

    // Persistir a atualização
    await _geralPersist.Editar(FuncionarioExistente);

    // Retorna a resposta com o objeto atualizado
    return Ok(FuncionarioExistente);
}}
    
}