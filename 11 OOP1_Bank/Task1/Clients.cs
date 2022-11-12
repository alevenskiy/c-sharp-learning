using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Task1
{
    class Clients
    {
        internal class Client
        {
            internal string surname { set; get; }
            internal string name { set; get; }
            internal string secondName { set; get; }
            internal string phoneNumber { set; get; }
            internal string passportNumber { set; get; }

            Client() : base()
            {
                surname = "";
                name = "";
                secondName = "";
                phoneNumber = "";
                passportNumber = "";
            }

            public Client(string surname, string name, string secondname, string phoneNumber, string passportNumber)
            {
                this.surname = surname;
                this.name = name;
                this.secondName = secondname;
                this.phoneNumber = phoneNumber;
                this.passportNumber = passportNumber;
            }
        }

        private List<Client> clients;

        public Clients()
        {
            string str = File.ReadAllText("clients.json");
            clients = JsonConvert.DeserializeObject<List<Client>>(str);
        }

        public void Serialize()
        {
            JArray jArray = new JArray();

            foreach (Client client in clients)
            {
                JObject jObject = new JObject();
                jObject["surname"] = client.surname;
                jObject["name"] = client.name;
                jObject["secondname"] = client.secondName;
                jObject["phoneNumber"] = client.phoneNumber;
                jObject["passportNumber"] = client.passportNumber;
                jArray.Add(jObject);
            }

            string json = jArray.ToString();
            File.WriteAllText("clients.json", json);
        }
    }
}
