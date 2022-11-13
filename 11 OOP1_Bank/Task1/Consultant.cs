using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Consultant
    {
        Client client;
        public Consultant() 
        {
            client = new Client().Deserialize("client.json");
        }
        
        public void ShowClient()
        {
            Console.WriteLine("Client:\nSurname: " + client.surname);
            Console.WriteLine("Name: " + client.name);
            Console.WriteLine("Second Name: " + client.secondName);
            Console.WriteLine("Phone Number: " + client.phoneNumber);
            Console.Write("Passpot Number: ");
            if (client.passportNumber != "")
                Console.WriteLine("*****************");
        }

        public void PhoneNumberChange()
        {
            string newPhone = "";
            while(newPhone == "")
            {
                Console.WriteLine("input new phone number");
                newPhone = Console.ReadLine();
                if (newPhone == "")
                    Console.WriteLine("phone number cannot be empty");
                else
                {
                    client.phoneNumber = newPhone;
                    Console.WriteLine("phone number changed");
                    client.Serialize("client.json");
                }
            }
        }
    }
}
