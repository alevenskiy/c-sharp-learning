using System;
using System.Xml.Serialization;
using System.Xml.Linq;

namespace Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            XElement person = new XElement("Person");

            Console.WriteLine("input name");
            string str = Console.ReadLine();
            XAttribute name = new XAttribute("Name", str);
            
            person.Add(name);

            XElement address = new XElement("Address");
            XElement street = new XElement("Street");
            XElement houseNumber = new XElement("HouseNumber");
            XElement flatNumber = new XElement("FlatNumber");

            Console.WriteLine("input street");
            str = Console.ReadLine();
            street.Add(str);
            
            Console.WriteLine("input house number");
            str = Console.ReadLine();
            houseNumber.Add(str);
            
            Console.WriteLine("input flat number");
            str = Console.ReadLine();
            flatNumber.Add(str);

            address.Add(street);
            address.Add(houseNumber);
            address.Add(flatNumber);

            XElement phones = new XElement("Phones");
            XElement mobilePhone = new XElement("MobilePhone");
            XElement flatPhone = new XElement("FlatPhone");

            Console.WriteLine("input mobile phone number");
            str = Console.ReadLine();
            mobilePhone.Add(str);

            Console.WriteLine("input flat phone number");
            str = Console.ReadLine();
            flatPhone.Add(str);

            phones.Add(mobilePhone);
            phones.Add(flatPhone);

            person.Add(address);
            person.Add(phones);

            person.Save("_Person.xml");
        }
    }
}
