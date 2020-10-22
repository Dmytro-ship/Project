using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using WinZoo.DataBase.Date;

namespace WinZoo.DataBase.Workers
{
    class Human : Date.Date
    {
        int ID;
        string Login;
        string Password;
        string PIB;
        Date.Date Birthday;
        string number_phone;

        public Human(Human obj)
        {
            this.ID = obj.ID;
            this.Login = obj.Login;
            this.Password = obj.Password;
            this.PIB = obj.PIB;
            Birthday = new Date.Date();
            Birthday.Set_Day(obj.Birthday.Get_Day());
            Birthday.Set_Month(obj.Birthday.Get_Month());
            Birthday.Set_Year(obj.Birthday.Get_Year());
            this.number_phone = obj.number_phone;
        }
        public Human() {
            
            ID = 0;
            Login = "";
            Password = "";
            PIB = "";
            Birthday = new Date.Date();
            number_phone = "";
        }
        public bool Log_in(string Login, string Password)
        {
            DB.DataBase dataBase = new DB.DataBase();
            dataBase.Zoo_Connect();
            try
                {
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlCommand command = new MySqlCommand("SELECT * FROM `human` WHERE `login` = @LogUser AND `password` = @PassUser", dataBase.Get_Connection_Zoo());
                command.Parameters.Add("@LogUser", MySqlDbType.VarChar).Value = Login;
                command.Parameters.Add("@PassUser", MySqlDbType.VarChar).Value = Password;
                adapter.SelectCommand = command;
                adapter.Fill(table);
                if (table.Rows.Count > 0)
                {
                    Init_Human(table);
                    return true;
                }
                else return false;
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
            finally
            {
                if (dataBase.IsZoo_Open())
                    dataBase.Zoo_Disconnect();
                
            }
            return false;

        }
        private void Init_Human(DataTable table)
        {
            this.ID = Convert.ToInt32(table.Rows[0][0]);
            this.Login = Convert.ToString(table.Rows[0][1]);
            this.Password = Convert.ToString(table.Rows[0][2]);
            this.PIB = Convert.ToString(table.Rows[0][3]);
            string date = Convert.ToString(table.Rows[0][4]);
            Birthday.Convert_to_Date(date);
            this.number_phone = Convert.ToString(table.Rows[0][5]);
       
        }
        public void Edit_User_Data(string PIB, string date, string number_phone) { }
        public void Change_Password(string password) { }
        public bool Is_login_user() { return ID > 0; }

        public int Get_ID() { return ID; }
    }
}
