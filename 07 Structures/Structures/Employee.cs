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

        public int Id{ get; set; }
        public DateTime Date{ get; set; }  
        public string Name{ get; set; }
        public int Age{ get; set; }
        public int Height { get; set; }
        public DateTime BirthDate{ get; set; }
        public string BirthCity { get; set; }

        public string ToString(char splitChar)
        {

            StringBuilder str = new StringBuilder();
            str.Append(this.Id);
            str.Append(splitChar);
            str.Append(this.Date);
            str.Append(splitChar);
            str.Append(this.Name);
            str.Append(splitChar);
            str.Append(this.age);
            str.Append(splitChar);
            str.Append(this.height);
            str.Append(splitChar);
            str.Append(this.birthDate);
            str.Append(splitChar);
            str.Append(this.BirthCity);

            return str.ToString();
        }
    }
}
