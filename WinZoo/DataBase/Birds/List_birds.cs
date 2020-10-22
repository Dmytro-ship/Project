using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinZoo.DataBase.DB;
using WinZoo.DataBase.Live_zone;
using WinZoo.DataBase.Workers;

namespace WinZoo.DataBase.Birds
{
    class List_birds
    {
        private List<Birds> birds;
        List_birds()
        {
            birds = new List<Birds>();
        }
        List_birds(List<Birds> birds)
        {
            foreach (Birds i in birds)
            {
                this.birds.Add(i);
            }
        }
        public List<Birds> Get_Birds() { return birds; }
        public void Init_by_Id_Human(Worker worker)
        {
            //Беру об^єкт замість простого int, щоб запобігти якихось маніпуляцій з сторони юзера

            DB.DataBase database = new DB.DataBase();
            try
            {
                database.Zoo_Connect();
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlCommand command = new MySqlCommand("SELECT * FROM `birds` WHERE `ID_worker` = @ID", database.Get_Connection_Zoo());
                command.Parameters.Add("@LogUser", MySqlDbType.Int32).Value = worker.Get_ID();
                adapter.SelectCommand = command;
                adapter.Fill(table);
                if (table.Rows.Count > 0)
                {
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        Birds temp_bird = new DataBase.Birds.Birds();
                        temp_bird.Set_ID(Convert.ToInt32(table.Rows[i][0]));
                        temp_bird.Set_Name(Convert.ToString(table.Rows[i][1]));
                        temp_bird.Set_Age(Convert.ToInt32(table.Rows[i][2]));
                        Date.Date temp_date = new Date.Date();
                        temp_date.Convert_to_Date(Convert.ToString(table.Rows[i][3]));
                        temp_bird.Set_Birthday(temp_date);
                        temp_bird.Set_Description(Convert.ToString(table.Rows[i][4]));
                        Date.DateTime temp_dateTime = new Date.DateTime();
                        temp_dateTime.Convert_to_DiteTime(Convert.ToString(table.Rows[i][5]));
                        temp_bird.Set_Lifetime(temp_dateTime);
                        temp_dateTime.Convert_to_DiteTime(Convert.ToString(table.Rows[i][6]));
                        Ration.Ration temp_ration = new Ration.Ration();
                        //ініціалізація раціону, дописати!!
                        temp_bird.Set_Ration(temp_ration);
                        Departure_of_birds temp_departure_Of_Birds = new Departure_of_birds();
                        //дописати ініт відльоту птахів!
                        temp_bird.Set_Departure(temp_departure_Of_Birds);
                        Live_zone.Living_area temp_living_Area = new Live_zone.Living_area();
                        //дописати ініт зони проживання!!
                        temp_bird.Set_Area(temp_living_Area);

                        this.birds.Add(temp_bird);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
            finally
            {
                if (database.IsZoo_Open())
                    database.Zoo_Disconnect();

            }
        }
    }
}
