using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using WinZoo.DataBase;
//sing WinZoo.DataBase.Date;

namespace WinZoo.DataBase.Workers
{
    class Worker
    {
        private Human human;
        private int ID_worker;
        private string Position;
        private Date.Date Date_of_dismissal;
        private Date.Date Date_of_employment;
        private double Salary;

        public Human Get_Human() { return human; }
        public int Get_ID() { return ID_worker; }
        public string Get_Position() { return Position; }
        public Date.Date Get_Date_dismissal() { return Date_of_dismissal; }
        public Date.Date Get_Date_employment() { return Date_of_employment; }
        public double Get_Salary() { return Salary; }
        public void Set_ID(int id) { this.ID_worker = id; }
        public void Set_human(Human obj) { this.human = new Human(obj); }
        public void Set_Position(string position) { this.Position = position; }
        public void Set_Date_dismissal(Date.Date obj) { this.Date_of_dismissal = new Date.Date(obj); }
        public void Set_Date_employment(Date.Date obj) { this.Date_of_employment = new Date.Date(obj); }
        public void Set_Salary(double Salary) { this.Salary = Salary; }
        public Worker() 
        { 
            human = new Human();
            ID_worker = 0;
            Position = "";
            Date_of_dismissal = new Date.Date();
            Date_of_employment = new Date.Date();
            Salary = 0;
        }
        public Worker(Worker obj)
        {
            this.human = new Human(obj.human);
            this.ID_worker = obj.ID_worker;
            this.Position = obj.Position;
            this.Date_of_dismissal = new Date.Date(obj.Date_of_dismissal);
            this.Date_of_employment = new Date.Date(obj.Date_of_employment);
            this.Salary = obj.Salary;
        }
        public Worker(Human obj)
        {
            human = new Human(obj);
            if(human.Get_ID() > 0)
            {
                Initial_Worker_By_DB();
            }
            else
            {
                ID_worker = 0;
                Position = "";
                Date_of_dismissal = new Date.Date();
                Date_of_employment = new Date.Date();
                Salary = 0;
            }
        }
        private void Initial_Worker_By_DB()
        {
            if (human.Is_login_user())
            {
                DB.DataBase dataBase = new DB.DataBase();
                dataBase.Zoo_Connect();
                if (dataBase.IsZoo_Open())
                {
                    DataTable table = new DataTable();
                    MySqlDataAdapter adapter = new MySqlDataAdapter();
                    MySqlCommand command = new MySqlCommand("SELECT * FROM `worker` WHERE `ID_human` = @ID_hum", dataBase.Get_Connection_Zoo());
                    command.Parameters.Add("@ID_hum", MySqlDbType.Int32).Value = human.Get_ID();
                    adapter.SelectCommand = command;
                    adapter.Fill(table);

                    ID_worker = Convert.ToInt32(table.Rows[0][0]);
                    Position = Convert.ToString(table.Rows[0][2]);
                    Date_of_employment = new Date.Date();
                    Date_of_dismissal = new Date.Date();
                    Date_of_employment.Convert_to_Date(Convert.ToString(table.Rows[0][3]));
                    Date_of_dismissal.Convert_to_Date(Convert.ToString(table.Rows[0][4]));
                    Salary = Convert.ToDouble(table.Rows[0][5]);
                    dataBase.Zoo_Disconnect();
                }
                else
                    System.Windows.MessageBox.Show("База даних не відчинена!");
            }
        }
    }
}
