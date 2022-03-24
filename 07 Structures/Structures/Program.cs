using System;
using System.IO;
using System.Text;

namespace Structures
{
    internal class Program
    {
        /// <summary>
        /// 1. Вывод на экран записи по id
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="filename">Путь до файла и его имя</param>
        static void ShowEmployeeByID(int id, string filename)
        {
            if (File.Exists(filename))
            {
                using (StreamReader sr = new StreamReader(filename))
                {
                    string line;
                    string[] parts;
                    while ((line = sr.ReadLine()) != null)
                    {
                        parts = line.Split('#');
                        if (id == Convert.ToInt32(parts[0]))
                        {
                            Console.WriteLine(line.Replace('#', ' '));
                            return;
                        }
                    }
                }
                Console.WriteLine("There is no Employee with this id");
            }
            else
                Console.WriteLine("There is no file with this name");
        }

        /// <summary>
        /// 2. Создание записи в файле
        /// </summary>
        /// <param name="emp">Готовый сотрудник. ID и Дата перезапишутся</param>
        /// <param name="filename">Путь до файла и его имя</param>
        static void AddEmployeeToFile(Employee emp, string filename)
        {
            int id = 0;
            string date = DateTime.Now.ToString("dd.MM.yyyy HH:mm");

            if (File.Exists(filename))
                id = getLastID(filename);
            id++;

            using (StreamWriter sw = new StreamWriter(filename, true))
            {
                sw.WriteLine(emp.ToString('#'));
            }
        }

        /// <summary>
        /// 3. Удаление записи из файла по ID
        /// </summary>
        /// <param name="id">ID сотрудника в файле</param>
        /// <param name="filename">Путь до файла и его имя</param>
        static void DeleteEmployeeFromFile(int id, string filename)
        {
            int listSize = GetSizeList(filename);
            Employee[] emps = new Employee[listSize];
            bool flag = false;
            int ind = 0;

            using (StreamReader sr = new StreamReader(filename))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    emps[ind] = new Employee(line, '#');
                    if (emps[ind].Id == id)
                    {
                        flag = true;
                        break;
                    }
                    ind++;
                }
            }
            if (flag)
            {
                using (StreamWriter sw = new StreamWriter(filename, false))
                {
                    for (int i = 0; i < emps.Length; i++)
                    {
                        if (ind == i)
                            continue;
                        else
                            sw.WriteLine(emps[i].ToString('#'));
                    }
                }
            }
            else
                Console.WriteLine("There is no Employee with this ID");
        }

        /// <summary>
        /// 4. Возвращение записи из файла для дальнейшего редактирования
        /// </summary>
        /// <param name="id">ID сотрудника в файле</param>
        /// <param name="filename">Путь до файла и его имя</param>
        /// <returns></returns>
        static Employee GetEmployeeFromFile(int id, string filename)
        {
            using (StreamReader sr = new StreamReader(filename))
            {
                string line;
                string[] parts;
                while ((line = sr.ReadLine()) != null)
                {
                    parts = line.Split('#');
                    if (id == Convert.ToInt32(parts[0]))
                    {
                        return new Employee(line, '#');
                    }
                }
                Console.WriteLine("There is no Employee with this id");
                return new Employee();
            }
        }

        /// <summary>
        /// 5. Возвращение списка сотрудников в заданном диапазоне дат создания
        /// </summary>
        /// <param name="from">начало диапазона</param>
        /// <param name="to">конец диапазона</param>
        /// <param name="filename">путь к фалу и его имя</param>
        /// <returns></returns>
        static Employee[] GetEmployeesDateRange(DateTime from, DateTime to, string filename)
        {
            int size = GetSizeList(filename);
            Employee[] employees = new Employee[size];
            int count = 0;

            using (StreamReader sr = new StreamReader(filename))
            {
                string line;

                while((line = sr.ReadLine()) != null)
                {
                    Employee emp = new Employee(line, '#');
                    if (emp.Date > from && emp.Date < to)
                    {
                        employees[count] = emp;
                        count++;
                    }
                }
            }
            Employee[] rangedEmployees = new Employee[count];
            for (int i = 0; i < count; i++)
                rangedEmployees[i] = employees[i];

            return rangedEmployees;
        }

        /// <summary>
        /// 6. Возвращение отсортированного по дате списка сотрудников
        /// </summary>
        /// <param name="upper">true - по увелечению, false - по убыванию</param>
        /// <param name="filename">путь до файла и его название</param>
        /// <returns></returns>
        static Employee[] GetSortedEmployees(bool upper, string filename)
        {
            int size = GetSizeList(filename);
            Employee[] employees = new Employee[size];

            using (StreamReader sr = new StreamReader(filename))
            {
                string line;
                int index = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    employees[index] = new Employee(line, '#');
                }
            }

            DateTime tmpDate;

            for (int i = 0; i < size; i++)
            {
                for (int j = size - 1; j > i; j--)
                {
                    if (upper)
                    {
                        if (employees[j - 1].Date > employees[j].Date)
                        {
                            tmpDate = employees[j - 1].Date;
                            employees[j - 1].Date = employees[j].Date;
                            employees[j].Date = tmpDate;
                        }
                    }
                    else
                    {
                        if (employees[j - 1].Date < employees[j].Date)
                        {
                            tmpDate = employees[j - 1].Date;
                            employees[j - 1].Date = employees[j].Date;
                            employees[j].Date = tmpDate;
                        }
                    }
                }
            }
            return employees;
        }

        static void Main(string[] args)
        {
            string filename = "list.txt";

            #region last hw main
            /*while (true)
            {
                Console.WriteLine("\nEnter 1 to show data\n" +
                    "Enter 2 to enter data and add it to file\n" +
                    "Enter 0 to close");
                string choice = Console.ReadLine();

                if (choice == "0")
                    break;

                switch (choice)
                {
                    case "1":
                        FileInfo f = new FileInfo(filename);
                        if (f.Exists)
                            showFileData(filename);
                        break;

                    case "2":
                        addLineToFile(enterData(), filename);
                        break;

                    default: break;
                }
            }*/
            #endregion
        }

        static int GetSizeList(string filename)
        {
            int count = 0;
            string readLine;
            using (StreamReader sr = new StreamReader(filename))
            {
                while ((readLine = sr.ReadLine()) != null)
                    count++;
            }
            return count;
        }

        static void showFileData(string fileName)
        {
            StreamReader sr = new StreamReader(fileName);

            string line;
            while ((line = sr.ReadLine()) != null)
                Console.WriteLine(line.Replace("#", " "));

            sr.Close();
        }

        static int getLastID(string filename)
        {
            int id = 0;
            string readLine;
            using (StreamReader sr = new StreamReader(filename))
            {
                while ((readLine = sr.ReadLine()) != null)
                {
                    string[] splittedLine = readLine.Split('#');
                    id = Convert.ToInt32(splittedLine[0]);
                }
            }
            return id;
        }

        static void addLineToFile(string line, string fileName)
        {
            int id = 0;
            string date = DateTime.Now.ToString("dd.MM.yyyy HH:mm");

            FileInfo f = new FileInfo(fileName);
            if (f.Exists)
                id = getLastID(fileName);
            id++;

            string writeLine = id.ToString() + "#" + date + "#" + line;

            using (StreamWriter sw = new StreamWriter(fileName, true))
            {
                sw.WriteLine(writeLine);
            }
        }

        static string enterData()
        {
            Console.WriteLine("enter Surname Name SecondName");
            StringBuilder line = new StringBuilder(Console.ReadLine());
            line.Append('#');
            Console.WriteLine("enter Age");
            line.Append(Console.ReadLine());
            line.Append('#');
            Console.WriteLine("enter Height");
            line.Append(Console.ReadLine());
            line.Append('#');
            Console.WriteLine("enter Birth Date");
            line.Append(Console.ReadLine());
            line.Append('#');
            Console.WriteLine("enter Birth Place");
            line.Append(Console.ReadLine());

            return line.ToString();
        }
    }
}
