using System;
using System.Collections.Generic;
using System.Text;

namespace Structures
{
    struct Employee
    {

        public Employee(int id,
                        DateTime date, 
                        string name, 
                        int age, 
                        int height, 
                        DateTime birthDate, 
                        string birthCity) : this()
        {
            this.Id = id;
            this.Date = date;
            this.Name = name;
            this.Age = age;
            this.Height = height;
            this.BirthDate = birthDate;
            this.BirthCity = birthCity;
        }

        public Employee(string line, char splittedChar)
        {
            string[] parts = line.Split(splittedChar);
            Id = Convert.ToInt32(parts[0]);
            Date = Convert.ToDateTime(parts[1]);
            Name = parts[2];
            Age = Convert.ToInt32(parts[3]);
            Height = Convert.ToInt32(parts[4]);
            BirthDate = Convert.ToDateTime(parts[5]);
            BirthCity = parts[6];
        }

        public Employee(string[] parts)
        {
            Id = Convert.ToInt32(parts[0]);
            Date = Convert.ToDateTime(parts[1]);
            Name = parts[2];
            Age = Convert.ToInt32(parts[3]);
            Height = Convert.ToInt32(parts[4]);
            BirthDate = Convert.ToDateTime(parts[5]);
            BirthCity = parts[6];
        }


        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public int Height { get; set; }

        public DateTime BirthDate { get; set; }

        public string BirthCity { get; set; }


        public string ToString(char splitChar)
        {

            StringBuilder str = new StringBuilder();
            str.Append(this.Id.ToString());
            str.Append(splitChar);
            str.Append(this.Date.ToString());
            str.Append(splitChar);
            str.Append(this.Name);
            str.Append(splitChar);
            str.Append(this.Age.ToString());
            str.Append(splitChar);
            str.Append(this.Height.ToString());
            str.Append(splitChar);
            str.Append(this.BirthDate.ToString("dd/MM/yyyy"));
            str.Append(splitChar);
            str.Append(this.BirthCity);

            return str.ToString();
        }
    }
}
