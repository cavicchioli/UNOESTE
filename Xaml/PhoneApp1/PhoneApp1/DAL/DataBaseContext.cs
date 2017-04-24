using PhoneApp1.Model;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneApp1.DAL
{
    public class DataBaseContext : DataContext
    {
        public static string ConnectionString = "Data Source=isostore:/Database.sdf";

        public Table<Produto> Produtos;

        public DataBaseContext(string conexao)
            : base(conexao)
        {
            if (!this.DatabaseExists())
                this.CreateDatabase();
        }
    }
}
