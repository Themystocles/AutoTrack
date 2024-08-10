using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoTrackApi.Model;

namespace AutoTrackApi.Interface
{
    public interface IMontagemPersist
    {
        Task<IEnumerable<Montagem>> GetMontagemsByData(string dataMont);
    }
}