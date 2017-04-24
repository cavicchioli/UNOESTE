using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploPos.Model
{
    internal partial class HelpDeskEntities : DbContext
    {
        internal HelpDeskEntities(string conexao) : base(conexao) { }
    }
}
