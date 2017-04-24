using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneApp1.Model
{
    [Table]
    public class Atendimento
    {
        [Column(IsPrimaryKey = true, CanBeNull = false, IsDbGenerated = true)]
        public int ID { get; set; }
        [Column]
        public string IdCliente { get; set; }
        [Column]
        public DateTime DataInicial { get; set; }
        [Column]
        public DateTime HoraInicial { get; set; }
        [Column]
        public DateTime? DataFinal { get; set; }
        [Column]
        public DateTime? HoraFinal { get; set; }
        [Column]
        public string Latitude { get; set; }
        [Column]
        public string Longitude { get; set; }
    }
}
