using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneApp1.Model;

namespace PhoneApp1.DAL
{
    public class DataBaseContext : DataContext
    {
        public static string ConnectionString = "DataSource=isostore:/Database.sdf";

        public Table<Atendimento> Atendimentos;

        public DataBaseContext(string conexao)
            : base(conexao)
        {
            if (!this.DatabaseExists())
                this.CreateDatabase();
        }
    }
}
