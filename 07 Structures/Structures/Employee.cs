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

        public int Id{ get; set; }
        public DateTime Date{ get; set; }  
        public string Name{ get; set; }
        public int Age{ get; set; }
        public int Height { get; set; }
        public DateTime BirthDate{ get; set; }
        public string BirthCity { get; set; }

    }
}
