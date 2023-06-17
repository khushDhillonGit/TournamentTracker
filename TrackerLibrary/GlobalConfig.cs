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
        public static List<IDataConection> Connections { get; private set; } = new List<IDataConection>();

        public static void InitializeConnections(bool database, bool textFiles) 
        {
            if (database) 
            { 
                // TODO SetUpSQl Connecter properly
                SqlConnecter sql = new SqlConnecter();
                Connections.Add(sql);
            }

            if (textFiles) 
            { 
                //TODO  setup text file properly
                TextConnecter textConnecter = new TextConnecter();
                Connections.Add(textConnecter);
            }
        }
        public static string CnnString(string name) { 
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }

    


}
