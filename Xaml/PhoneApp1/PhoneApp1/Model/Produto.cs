using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneApp1.Model
{
    [Table]

    public class Produto
    {
        [Column(IsPrimaryKey=true, CanBeNull=false, IsDbGenerated=true)]
        public int ID { get; set; }

        [Column]
        public string Nome { get; set; }

        [Column]
        public string Marca { get; set; }

        [Column]
        public bool Selecionado { get; set; }

    }
}
