using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WinZoo.DataBase.DB
{
    class DataBase
    {

        MySqlConnection connection = new MySqlConnection("server=localhost;port=3307;username=root;password=root;database=zoo;");

        public void Zoo_Connect()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                    connection.Open();
            }
            else System.Windows.MessageBox.Show("База даних не знайдена!");
 
        }
        public void Zoo_Disconnect()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
        public MySqlConnection Get_Connection_Zoo()
        {
            return connection;
        }
        public bool IsZoo_Open()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                return true;
            }
            return false;
        }
    }
}
