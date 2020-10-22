using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinZoo.DataBase.Date
{
    class DateTime
    {
        private Date date;
        private Time time;

        public DateTime()
        {
            this.date = new Date();
            this.time = new Time();
        }
        DateTime(Date date, Time time) 
        {
            this.date = new Date(date);
            this.time = new Time(time);
        }
        public Date Get_Date() { return date; }
        public Time Get_Time() { return time; }
        public void Set_Date(Date date)
        {
            this.date = date;
        }
        public void Set_Time(Time time)
        {
            this.time = time;
        }

        public void Convert_to_DiteTime(string Date_Time)
        {
            date.Convert_to_Date(Date_Time);
            time.Convert_to_time(Date_Time);
        }
    }
}
