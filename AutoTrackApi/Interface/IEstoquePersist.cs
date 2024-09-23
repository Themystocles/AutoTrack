using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoTrackApi.Model.Entities;

namespace AutoTrackApi.Interface
{
    public interface IEstoquePersist
    {
        Task<Estoque> GetEstoqueById(int id);

         Task AtualizarEstoqueAsync(string nomeServico, int quantidade);

         Task <IEnumerable<Estoque>> Estoqueminimo();

        
    }
}