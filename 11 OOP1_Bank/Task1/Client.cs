using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Task1
{
    public class Client
    {
        public string surname { set;  get; }
        public string name { set; get; }
        public string secondName { set; get; }
        public string phoneNumber { set; get; }
        public string passportNumber { set; get; }

        

        public Client Deserialize(string path)
        {
            string str = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<Client>(str);
        }

        public void Serialize(string path)
        {

            JObject jObject = new JObject();
            jObject["surname"] = surname;
            jObject["name"] = name;
            jObject["secondName"] = secondName;
            jObject["phoneNumber"] = phoneNumber;
            jObject["passportNumber"] = passportNumber;

            string json = jObject.ToString();
            File.WriteAllText(path, json);
        }
    }
}
