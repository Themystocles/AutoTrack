using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoTrackApi.DataContext;
using AutoTrackApi.Interface;
using AutoTrackApi.Model;
using Microsoft.EntityFrameworkCore;


namespace AutoTrackApi.Persistencia
{
    
    public class VeiculoPersist: IVeiculoPersist
    {
    private readonly ConnectionContext _context;
    public VeiculoPersist(ConnectionContext context)
        {
            _context = context;
        }

        public async Task<Veiculo> GetVeiculoByChassi(string chassi)
        {
            var veiculo = await _context.Veiculos
            .Include(v => v.Cliente) // Inclui o cliente relacionado
            .Include(v => v.servicos)
            .ThenInclude(o => o.orcamentos)
            .Include(m => m.montagens)
            .ThenInclude(o => o.orcamentos) // Inclui os serviços relacionados
            .FirstOrDefaultAsync(v => v.Chassi.ToLower() == chassi.ToLower());

        return veiculo;
           
        }

        public async Task<Veiculo> GetVeiculoByID(int IDveiculo)
        {
            return await _context.Veiculos.FirstOrDefaultAsync(c=> c.Id == IDveiculo);
        }

        public async Task<Veiculo> GetVeiculoByPlaca(string placa)
        {
             var veiculo = await _context.Veiculos
            .Include(v => v.Cliente) // Inclui o cliente relacionado
            .Include(v => v.servicos)
            .ThenInclude(o => o.orcamentos) // Inclui os serviços relacionados
            .Include(m => m.montagens)
            .ThenInclude(o => o.orcamentos)
            .FirstOrDefaultAsync(v => v.Placa.ToLower() == placa.ToLower());

        return veiculo;
        }

       

        public async Task<bool> VeiculoplacaoExistsAsync (string placa)
        {
             if (string.IsNullOrEmpty(placa)){
            return false;
         }
         return await _context.Veiculos.AnyAsync(v => v.Placa == placa);
        
        }

        public async Task<bool> VeiculochassiExistsAsync(string chassi)
        {
            if (string.IsNullOrEmpty(chassi)){
                return false;

            }
            return await _context.Veiculos.AnyAsync(v => v.Chassi == chassi);
        }
    }
}