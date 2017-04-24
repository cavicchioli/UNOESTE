using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploPos
{
    internal static class Util
    {
        internal static string ConnectionString
        {
            get
            {
                return @"metadata=res://*/Model.HelpDesk.csdl|res://*/Model.HelpDesk.ssdl|res://*/Model.HelpDesk.msl;provider=System.Data.SqlClient;provider connection string='data source=localhost\sqlexpress;initial catalog=HelpDesk;persist security info=True;user id=sa;password=a12345z;MultipleActiveResultSets=True;App=EntityFramework'";
            }
        }
    }
}
