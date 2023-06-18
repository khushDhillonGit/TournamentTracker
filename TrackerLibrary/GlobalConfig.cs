using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.DataAccess;
using System.Configuration;

namespace TrackerLibrary
{
    public static class GlobalConfig
    {
        public static IDataConection Connection { get; private set; }

        public static void InitializeConnections(DatabaseType db) 
        {
            if (db == DatabaseType.Sql) 
            { 
                // TODO SetUpSQl Connecter properly
                SqlConnecter sql = new SqlConnecter();
                Connection = sql;
            }
            else if (db == DatabaseType.TextFile) 
            {
                //TODO  setup text file properly
                TextConnecter textConnecter = new TextConnecter();
                Connection = textConnecter;
            }
        }
        public static string CnnString(string name) { 
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }

    


}
