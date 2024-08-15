using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoTrackApi.Interface
{
    public interface IClientePersist
    {
        Task<Cliente> GetClienteByID(int id);
        Task<Cliente> GetClienteByCpf(string cpf);
        Task<Cliente> GetClienteBynumeroTel(string telefone);
        Task<List<Cliente>> GetClientesByNome(string nome);
        
    }
}