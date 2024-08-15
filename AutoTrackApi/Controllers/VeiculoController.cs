using AutoTrackApi.Interface;
using AutoTrackApi.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoTrack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VeiculoController : ControllerBase
    {
        private readonly IGeralPersist _geralPersist;

        private readonly IVeiculoPersist _veiculoPersist;
        

        public VeiculoController(IGeralPersist geralPersist,IVeiculoPersist veiculoPersist )
        {
            _geralPersist = geralPersist;
            _veiculoPersist = veiculoPersist;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Veiculo>>> GetVeiculos()
        {
            var veiculos = await _geralPersist.GetAll<Veiculo>();
            return Ok(veiculos);
        }

   
         [HttpGet("veiculo/{placa}")]
        public async Task<ActionResult<IEnumerable<Veiculo>>> getVeiculoByPlaca(string placa)
        {
             var veiculo = await _veiculoPersist.GetVeiculoByPlaca(placa);
            if (veiculo == null)
            {
                return NotFound();
            }
            return Ok(veiculo);
        }
         [HttpGet("chassi/{chassi}")]
        public async Task<ActionResult<IEnumerable<Veiculo>>> getVeiculoByChassi(string chassi)
        {
            var veiculo = await _veiculoPersist.GetVeiculoByChassi(chassi);
            if (veiculo == null)
            {
                return NotFound();
            }
            return Ok(veiculo);
        } 
         [HttpGet("id/{id}")]
        public async Task<ActionResult<Veiculo>> GetVeiculoById(int id)
        {
            var veiculo = await _veiculoPersist.GetVeiculoByID(id);
            if (veiculo == null)
            {
                return NotFound();
            }
            return Ok(veiculo);
        }
    }
}
