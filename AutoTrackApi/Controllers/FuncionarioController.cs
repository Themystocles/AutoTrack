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


       

     
    }
}