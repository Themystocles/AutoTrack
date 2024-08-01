using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoTrackApi.Interface
{
   public interface IGeralPersist
    {
        Task AddAsync<T>(T entity) where T : class;
        Task<IEnumerable<T>> GetAll<T>() where T : class;

        Task<Cliente> GetClienteByCpf(string cpf);
        Task<Cliente> GetClienteBynumeroTel(string telefone);
    }
}