using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoTrackApi.Model;

namespace AutoTrackApi.Interface
{
    public interface IVeiculoPersist
    {
        Task<Veiculo> GetVeiculoByPlaca(string placa);
        Task<Veiculo> GetVeiculoByChassi(string chassi);
        Task<Veiculo> GetVeiculoByID(int ID);
        Task<bool> VeiculoplacaoExistsAsync(string placa);
        Task<bool> VeiculochassiExistsAsync(string chassi);
       
    }
}