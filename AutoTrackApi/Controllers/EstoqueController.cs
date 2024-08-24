using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoTrackApi.Interface;
using AutoTrackApi.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AutoTrackApi.Controllers
{
    [Route("api/[controller]")]
    public class EstoqueController : ControllerBase
    {
         private readonly IGeralPersist _geralPersist;
       
    public EstoqueController(IGeralPersist geralPersist)
        {
            _geralPersist = geralPersist;
        }
        [HttpGet("Estoque")]
        public async Task<ActionResult<IEnumerable<Estoque>>> GetAllEstoque()
        {
            var Estoque = await _geralPersist.GetAll<Estoque>();
            return Ok(Estoque);
        }


      

       
    }
}