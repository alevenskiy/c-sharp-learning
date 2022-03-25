using System;
using System.Collections.Generic;
using System.Text;

namespace Structures
{
    struct Employee
    {
        private int id;
        private DateTime date;
        private string name;
        private int age;
        private int height;
        private DateTime birthDate;
        private string birthCity;

        public Employee(int id,
                        DateTime date, 
                        string name, 
                        int age, 
                        int height, 
                        DateTime birthDate, 
                        string birthCity) : this()
        {
            this.id = id;
            this.date = date;
            this.name = name;
            this.age = age;
            this.height = height;
            this.birthDate = birthDate;
            this.birthCity = birthCity;
        }

        public Employee(string line, char splitChar) : this()
        {
            string[] parts = line.Split(splitChar);
            this.id = Convert.ToInt32(parts[0]);
            this.date = Convert.ToDateTime(parts[1]);
            this.name = parts[2];
            this.age = Convert.ToInt32(parts[3]);
            this.height = Convert.ToInt32(parts[4]);
            this.birthDate = Convert.ToDateTime(parts[5]);
            this.birthCity = parts[6];
        }

        //public int Id{ get; set; }
        public int GetID() { return id; }
        public void SetID(int id) { this.id = id; }
        //public DateTime Date{ get; set; } 
        public DateTime GetDate() { return date; }
        public void SetDate(DateTime date) { this.date = date; }
        //public string Name{ get; set; }
        public string GetName() { return name; }
        public void SetName(string name) { this.name = name; }
        //public int Age{ get; set; }
        public int GetAge() { return age; }
        public void SetAge(int age) { this.age = age; }
        //public int Height { get; set; }
        public int GetHeight() { return height; }
        public void SetHeight(int height) { this.height = height; }
        //public DateTime BirthDate{ get; set; }
        public DateTime GetBirthDate() { return birthDate; }
        public void SetBirthDate(DateTime birthDate) { this.birthDate = birthDate; }
        //public string BirthCity { get; set; }
        public string GetBirthCity() { return birthCity; }
        public void SetBirthCity(string birthCity) { this.birthCity = birthCity; }

        public string ToString(char splitChar)
        {

            StringBuilder str = new StringBuilder();
            str.Append(this.id.ToString());
            str.Append(splitChar);
            str.Append(this.date.ToString());
            str.Append(splitChar);
            str.Append(this.name);
            str.Append(splitChar);
            str.Append(this.age.ToString());
            str.Append(splitChar);
            str.Append(this.height.ToString());
            str.Append(splitChar);
            str.Append(this.birthDate.ToString("dd/MM/yyyy"));
            str.Append(splitChar);
            str.Append(this.birthCity);

            return str.ToString();
        }
    }
}
