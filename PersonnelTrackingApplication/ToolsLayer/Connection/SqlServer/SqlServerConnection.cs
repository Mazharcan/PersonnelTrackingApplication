using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelTrackingApplication.ToolsLayer.Connection.SqlServer
{
    public class SqlServerConnection
    {
        private static SqlConnection _connection; 

        public static SqlConnection Connection
        {
            get
            {
                if (_connection == null) 
                    _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["PersonnelTrackingSqlServer"].ConnectionString);
                return _connection;
            }
            set { _connection = value; }
        }

        public static void ConnectionOpen()
        {
            if (Connection.State == ConnectionState.Closed) 
                Connection.Open();
        }

        public static void ConnectionClose()
        {
            if (Connection.State == ConnectionState.Open) 
                Connection.Close();
        }
    }
}
