using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace AutoTrackApi.Interface
{
    public interface IClientePersist
    {
        Task<Cliente> GetClienteByID(int id);
        Task<Cliente> GetClienteByCpf(string cpf);
        Task<Cliente> GetClienteBynumeroTel(string telefone);
        Task<List<Cliente>> GetClientesByNome(string nome);

       Task<bool> ClienteExistsAsync(string cpf);
        
    }
}