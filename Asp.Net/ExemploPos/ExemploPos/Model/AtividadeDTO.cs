using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploPos.Model
{
    public class AtividadeDTO
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime ?DataFim { get; set; }
        public string Status { get; set; }
        public string Solicitante { get; set; }
    }
}
