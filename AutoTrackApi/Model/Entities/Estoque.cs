using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoTrackApi.Model.Entities
{
    public class Estoque
    {
        public int Id { get; set; }
        public string Produto { get; set; }
        public string Quantidade  { get; set; }
        public decimal Preco { get; set; }
        public string DataUltAlt { get; set; }
    }
}