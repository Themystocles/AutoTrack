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
         private readonly IEstoquePersist _estoquePersist;


        public EstoqueController(IGeralPersist geralPersist, IEstoquePersist estoquePersist)
        {
            _geralPersist = geralPersist;
             _estoquePersist = estoquePersist;
        }
        [HttpGet("Estoque")]
        public async Task<ActionResult<IEnumerable<Estoque>>> GetAllEstoque()
        {
            var Estoque = await _geralPersist.GetAll<Estoque>();
            return Ok(Estoque);
        }
         [HttpGet("Estoque/{id}")]
        public async Task<ActionResult<Estoque>> GetestoqueById(int id)
        {
            var Estoque = await _estoquePersist.GetEstoqueById(id);
            return Ok(Estoque);
        }
       [HttpPost("CadastrarItem")]
        public async Task<ActionResult<Estoque>> PostEstoque([FromBody]Estoque estoque)
        {
             _geralPersist.AddAsync(estoque);

             return CreatedAtAction(nameof(GetAllEstoque), new { id = estoque.Id }, estoque);
        }
          [HttpPut("EditarItem/{id}")]
        public async Task<ActionResult<Estoque>> PutEstoque(int id, [FromBody]Estoque estoque)
        {
             if (id != estoque.Id)
            {
                return BadRequest("O Id da URL não corresponde ao Id do Estoque.");
            }
             var Estoquerecebido = await _estoquePersist.GetEstoqueById(id);

             Estoquerecebido.Preco = estoque.Preco;
             Estoquerecebido.Produto = estoque.Produto;
             Estoquerecebido.Quantidade = estoque.Quantidade;
             Estoquerecebido.DataUltAlt = estoque.DataUltAlt;

              await _geralPersist.Editar(Estoquerecebido);


              return Ok(Estoquerecebido);
        }

        [HttpDelete("RemoverEstoque/{id}")]
        public async Task<ActionResult> DeleteEstoque(int id)
        {
           
             
             var Estoquerecebido = await _estoquePersist.GetEstoqueById(id);

            if (Estoquerecebido == null)
            {
                 return NotFound("Estoque não encontrado.");
            }
            await _geralPersist.Deletar(Estoquerecebido);
              // Retorna resposta de sucesso
            return NoContent();
                
             }


              
        }

      

       
    }
