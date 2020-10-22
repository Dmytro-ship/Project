using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinZoo.DataBase.Date;
using WinZoo.DataBase.Live_zone;
using WinZoo.DataBase.Ration;
using WinZoo.DataBase.Workers;

namespace WinZoo.DataBase.Birds
{
    class Birds
    {
        private int id;
        private string name;
        private Ration.Ration ration;
        private string description;
        private Date.Date birthday;
        private int age;
        private Date.DateTime lifetime;
        private Date.Time time_feeding;
        private Departure_of_birds departure;
        private Living_area living_area;
        public Birds()
        {
            this.id = 0;
            this.name = "";
            this.ration = new Ration.Ration();
            this.description = "";
            this.birthday = new Date.Date();
            this.age = 0;
            this.lifetime = new Date.DateTime();
            this.time_feeding = new Date.Time();
            this.departure = new Departure_of_birds();
            this.living_area = new Living_area();
        }
        public Birds(Birds obj)
        {
            this.id = obj.id;
            this.name = obj.name;
            //this.ration = new Ration.Ration(obj.ration);
            this.description = obj.description;
            this.birthday = new Date.Date(obj.birthday);
            this.age = obj.age;
            //this.lifetime = new Date.DateTime(obj.lifetime);
            this.time_feeding = new Date.Time(obj.time_feeding);
            //this.departure = new Departure_of_birds(obj.departure);
            //this.living_area = new Living_area(obj.living_area);
        }
        public int Get_ID() { return id; }
        public void Set_ID(int id) { this.id = id; }
        public string Get_Name() { return name; }
        public void Set_Name(string name) { this.name = name; }
        public Ration.Ration Get_Ration() { return ration; }
        public void Set_Ration(Ration.Ration ration) { this.ration = ration; }
        public string Get_description() { return description; }
        public void Set_Description(string description) { this.description = description; }
        public Date.Date Get_birthday() { return birthday; }
        public void Set_Birthday(Date.Date birthday) { this.birthday = birthday; }
        public int Get_Age() { return age; }
        public void Set_Age(int age) { this.age = age; }
        public Date.DateTime Get_lifetime() { return lifetime; }
        public void Set_Lifetime(Date.DateTime lifetime) { this.lifetime = lifetime; }
        public Date.Time Get_time_feeding() { return time_feeding; }
        public void Set_Feeding(Date.Time feeding) { this.time_feeding = feeding; }
        public Departure_of_birds Get_departure() { return departure; }
        public void Set_Departure(Departure_of_birds departure) { this.departure = departure; }
        public Living_area Get_living_area() { return living_area; }
        public void Set_Area(Living_area living_area) { this.living_area = living_area; }

        public void Edit_Animals(Animals.Animals animals)
        {
            DB.DataBase dataBase = new DB.DataBase();

            
        }
    }
}
