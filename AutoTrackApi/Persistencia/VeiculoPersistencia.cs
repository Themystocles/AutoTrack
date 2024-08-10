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
            .Include(m => m.montagens) // Inclui os serviços relacionados
            .FirstOrDefaultAsync(v => v.Chassi == chassi);

        return veiculo;
           
        } 

      

        public async Task<Veiculo> GetVeiculoByPlaca(string placa)
        {
             var veiculo = await _context.Veiculos
            .Include(v => v.Cliente) // Inclui o cliente relacionado
            .Include(v => v.servicos) // Inclui os serviços relacionados
            .Include(m => m.montagens)
            .FirstOrDefaultAsync(v => v.Placa == placa);

        return veiculo;
        }

    }
}