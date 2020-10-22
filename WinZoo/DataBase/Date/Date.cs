using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinZoo.DataBase.Date
{
    class Date
    {
        int day;
        int month;
        int year;
        public Date()
        {
            day = 0;
            month = 0;
            year = 0;
        }
        public Date(Date obj)
        {
            this.day = obj.day;
            this.month = obj.month;
            this.year = obj.year;
        }

        public void Set_Day(int day) { this.day = day; }
        public void Set_Month(int month) {this.month = month;}
        public void Set_Year(int year) { this.year = year; }
        public int Get_Day() { return day; }
        public int Get_Month() { return month; }
        public int Get_Year() { return year; }
        public void Convert_to_Date(string date)
        {
            System.Windows.MessageBox.Show(date);
            if (date != "NULL" && date != "" && date !="null" && date != null)
            {
                this.day = (Convert.ToInt32(date[0] + "" + date[1]));
                this.month = (Convert.ToInt32(date[3] + "" + date[4]));
                this.year = (Convert.ToInt32(date[6] + "" + date[7] + date[8] + date[9]));
            }
            else
            {
                this.day = 0;
                this.month = 0;
                this.year = 0;
            }
        }
    }
}
