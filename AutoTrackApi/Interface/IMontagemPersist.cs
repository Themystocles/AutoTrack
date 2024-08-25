using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoTrackApi.Model;

namespace AutoTrackApi.Interface
{
    public interface IMontagemPersist
    {
        Task<Montagem> GetMontagemById(int id);
        Task<IEnumerable<Montagem>> GetMontagemsByData(DateTime dataMont);
    }
}