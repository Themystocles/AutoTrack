using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoTrackApi.Model;

namespace AutoTrackApi.Interface
{
    public interface IServicoPersist
    {
        Task<IEnumerable<Servico>> GetServicosByDate(string dataserv);
    }
}