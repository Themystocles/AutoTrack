using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoTrackApi.Model.Entities;

namespace AutoTrackApi.Interface
{
    public interface IOrcamentoPersist
    {
        Task <IEnumerable<Orcamento>> getAllorc();
        Task <Orcamento> Delete(int id);
    }
}