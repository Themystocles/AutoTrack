using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoTrackApi.Model;

namespace AutoTrackApi.Interface
{
    public interface IServicoPersist
    {
        Task<Servico> GetServicoById(int id);
        Task<IEnumerable<Servico>> GetServicosByDate(DateTime dataserv);

        Task<IEnumerable<Servico>> GetServicosByTipo(string TipoServico);
        Task<int> GetCountServicosNaoPagos();

        Task<IEnumerable<Servico>> GetServicosNaoPagos();

        Task<IEnumerable<Servico>> GetServicosByAlertDate(DateTime dataalertaserv);

        Task<Servico> DeleteServico(int id);




    }
}