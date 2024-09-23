using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoTrack.Migrations;
using AutoTrackApi.Model;
using AutoTrackApi.Model.Entities;

namespace AutoTrackApi.Interface
{
    public interface IOrcamentoFuncionarioPersist
    {
         Task<IEnumerable<FuncionarioOrcamentosDTO>> ObterFuncionarioeOrcamentosAtrelados(DateTime dataInicio, DateTime dataFim);
    }
}