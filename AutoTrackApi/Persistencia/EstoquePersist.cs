using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoTrackApi.DataContext;
using AutoTrackApi.Interface;
using AutoTrackApi.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace AutoTrackApi.Persistencia
{
    public class EstoquePersist : IEstoquePersist
    {
        private readonly ConnectionContext _context;

        public EstoquePersist(ConnectionContext context)
        {
            _context = context;
        }

        public async Task AtualizarEstoqueAsync(string nomeServico, int quantidade)
        {
             var produtoEstoque = await _context.estoques
            .Where(e => e.Produto == nomeServico)
            .FirstOrDefaultAsync();

        if (produtoEstoque != null)
        {
            produtoEstoque.Quantidade -= quantidade;
            _context.estoques.Update(produtoEstoque);
            await _context.SaveChangesAsync();
        }
    }
        

        public async  Task<Estoque> GetEstoqueById(int id)
        {
           return await _context.estoques.FirstOrDefaultAsync(E => E.Id == id);
        }
    }
}