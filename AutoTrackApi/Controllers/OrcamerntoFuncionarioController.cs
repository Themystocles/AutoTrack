using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using AutoTrackApi.DataContext;
using AutoTrackApi.Persistencia;
using AutoTrackApi.Interface;
using AutoTrack.Migrations;
using AutoTrackApi.Model.Entities;

namespace AutoTrackApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrcamentoFuncionarioController : ControllerBase
    {

        private readonly ConnectionContext _context;
        private readonly IOrcamentoFuncionarioPersist _orcamentofuncpersist;

        public OrcamentoFuncionarioController(IOrcamentoFuncionarioPersist orcamentofuncpersist, ConnectionContext context)
        {
            _orcamentofuncpersist = orcamentofuncpersist;
            _context = context;
        }

        [HttpGet("funcionarioseOrcamentos")]
        public async Task<ActionResult<IEnumerable<OrcamentoFuncionario>>> getOrcamentoefuncionarios([FromQuery]DateTime dataInicio, DateTime dataFim)
        {
            var result = await _orcamentofuncpersist.ObterFuncionarioeOrcamentosAtrelados( dataInicio,  dataFim);
            return Ok(result);
        }


    }
}
