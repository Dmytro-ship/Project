using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinZoo.DataBase.Date
{
    class Time
    {
        private int hour;
        private int minute;
        private int second;
        public Time()
        {
            this.hour = 0;
            this.minute = 0;
            this.second = 0;
        }
        public Time(Time time)
        {
            this.hour = time.hour;
            this.minute = time.minute;
            this.second = time.second;
        }
        public void Set_Hour(int hour)
        {
            this.hour = hour;
        }
        public void Set_Minute(int minute)
        {
            this.minute = minute;
        }
        public void Set_Second(int second)
        {
            this.second = second;
        }
        public int Get_Hour() { return hour; }
        public int Get_Minute() { return minute; }
        public int Get_Second() { return second; }

        public void Convert_to_time(string time)
        {

        }

    }
}
