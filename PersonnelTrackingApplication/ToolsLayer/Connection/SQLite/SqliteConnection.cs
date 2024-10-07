using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Configuration;
using System.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using System.Drawing;

namespace PersonnelTrackingApplication.ToolsLayer.Connection.SQLite
{
    public class SqliteConnection   //this is my connection class
    {
        private static SQLiteConnection _connection; //A connection of type SQLiteConnection has been created

        public static SQLiteConnection Connection
        {
            get 
            {
                if (_connection == null)  //_connection null => Derive object from SqliteConnection class and assign this value        
                    _connection = new SQLiteConnection(ConfigurationManager.ConnectionStrings["PersonnelTrackingSqlite"].ConnectionString);
                return _connection;
            }
            set { _connection = value; }
        }

        public static void ConnectionOpen()
        {
            if (Connection.State == ConnectionState.Closed) // if the connection is closed > open
                Connection.Open();
        }

        public static void ConnectionClose()
        {
            if (Connection.State == ConnectionState.Open) // if the connection is open > close
                Connection.Close();
        }
    }
}
