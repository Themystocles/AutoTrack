using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoTrackApi.Interface
{
   public interface IGeralPersist
    {
        Task AddAsync<T>(T entity) where T : class;
         
        Task<T> GetByIdAsync<T>(int id) where T : class; 
        Task Editar<T>(T entity) where T : class;
        Task<IEnumerable<T>> GetAll<T>() where T : class;

        Task Deletar<T>(T entity) where T : class;

        Task<Cliente> GetClienteBynumeroTel(string telefone);
    }
}