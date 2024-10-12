using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoTrackApi.DataContext;
using AutoTrackApi.Interface;
using AutoTrackApi.Model.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
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

        public async Task AtualizarEstoqueExistenteAsync(string nomeServico, int novaQuantidade)
        {

            var produtoEstoque = await _context.estoques
                .Where(e => e.Produto == nomeServico)
                .FirstOrDefaultAsync();

            if (produtoEstoque != null)
            {

                produtoEstoque.Quantidade -= novaQuantidade;



                // Atualiza o produto no contexto
                _context.estoques.Update(produtoEstoque);

                // Salva as mudanças no banco de dados
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Estoque>> Estoqueminimo()
        {
            var estoquesminimos = await _context.estoques
           .Where<Estoque>(E => E.Quantidade < E.DataUltAlt)
           .ToListAsync();



            return estoquesminimos;
        }

        public async Task<Estoque> GetEstoqueById(int id)
        {
            return await _context.estoques.FirstOrDefaultAsync(E => E.Id == id);
        }
    }
}