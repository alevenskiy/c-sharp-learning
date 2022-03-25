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

            if (File.Exists(filename))
                id = getLastID(filename);
            id++;

            emp.SetID(id);

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
            int ind = -1;

            using (StreamReader sr = new StreamReader(filename))
            {
                string line;
                int i = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    emps[i] = new Employee(line, '#');
                    if (emps[i].GetID() == id)
                        ind = i;
                    i++;
                }
            }
            if (ind >= 0)
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
        /// 4. Взятие записи из файла для дальнейшего редактирования
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
        /// 4. Редактирование записи из файла, для дальнейшего возврата в файл
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        static Employee EditEmployee(Employee emp)
        {
            while (true)
            {
                Console.WriteLine("\n" +
                    "Enter 1 to change the Name\n" +
                    "Enter 2 to change the Age\n" +
                    "Enter 3 to change the Height\n" +
                    "Enter 4 to change the Birth Date\n" +
                    "Enter 5 to change the Birth City\n" +
                    "Enter 0 to save changes and exit edit menu\n");
                switch (Console.ReadLine())
                {
                    case "0":
                        return emp;
                    case "1":
                        Console.WriteLine("Enter Name");
                        emp.SetName(Console.ReadLine());
                        Console.WriteLine("Current Employee's data:\n" + emp.ToString(' '));
                        break;
                    case "2":
                        Console.WriteLine("Enter Age");
                        emp.SetAge(Convert.ToInt32(Console.ReadLine()));
                        Console.WriteLine("Current Employee's data:\n" + emp.ToString(' '));
                        break;
                    case "3":
                        Console.WriteLine("Enter Height");
                        emp.SetHeight(Convert.ToInt32(Console.ReadLine()));
                        Console.WriteLine("Current Employee's data:\n" + emp.ToString(' '));
                        break;
                    case "4":
                        Console.WriteLine("Enter Birth Date");
                        emp.SetBirthDate(Convert.ToDateTime(Console.ReadLine()));
                        Console.WriteLine("Current Employee's data:\n" + emp.ToString(' '));
                        break;
                    case "5":
                        Console.WriteLine("Enter Birth City");
                        emp.SetBirthCity(Console.ReadLine());
                        Console.WriteLine("Current Employee's data:\n" + emp.ToString(' '));
                        break;
                    default: break;

                }
            }
        }

        /// <summary>
        /// 4. Размещение записи в файле
        /// </summary>
        /// <param name="emp"></param>
        /// <param name="filename"></param>
        static void SetEmployeeInFile(Employee emp, string filename)
        {
            int size = 0;

            if (File.Exists(filename))
                size = getLastID(filename);
            
            Employee[] employees = new Employee[size];
            int index = 0;

            using(StreamReader sr = new StreamReader(filename))
            {
                string line;
                while((line = sr.ReadLine()) != null)
                {
                    employees[index] = new Employee(line, '#');
                    index++;
                }
            }
            for(int i = 0; i < size; i++)
            {
                if(employees[i].GetID() == emp.GetID())
                {
                    employees[i] = emp;
                    break;
                }
            }
            using (StreamWriter sw = new StreamWriter(filename, false))
            {
                for (int i = 0; i < size; i++)
                {
                    sw.WriteLine(employees[i].ToString('#'));
                }
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
                    if (emp.GetDate() > from && emp.GetDate() < to)
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
                    index++;
                }
            }

            Employee tmp;

            if (upper)
            {
                for (int i = 0; i + 1 < size; i++)
                {
                    for (int j = 0; j + 1 < size - i; j++)
                    {
                        if (employees[j + 1].GetDate() < employees[j].GetDate())
                        {
                            tmp = employees[j + 1];
                            employees[j + 1] = employees[j];
                            employees[j] = tmp;
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i + 1 < size; i++)
                {
                    for (int j = 0; j + 1 < size - i; j++)
                    {
                        if (employees[j + 1].GetDate() > employees[j].GetDate())
                        {
                            tmp = employees[j + 1];
                            employees[j + 1] = employees[j];
                            employees[j] = tmp;
                        }
                    }
                }
            }
            return employees;
        }

        /// <summary>
        /// 6. Сохранение списка сотрудников в файл
        /// </summary>
        /// <param name="emps"></param>
        /// <param name="filename"></param>
        static void SaveEmpoyeesListIntoFile(Employee[] emps, string filename)
        {
            using (StreamWriter sw = new StreamWriter(filename, false))
            {
                foreach (Employee employee in emps)
                {
                    sw.WriteLine(employee.ToString('#'));
                }
            }
        }

        static void Main(string[] args)
        {
            string filename = "list.txt";

            while (true)
            {
                Console.WriteLine("\n" + 
                    "Enter 1 to show list of Employees\n" +
                    "Enter 2 to show Employee by ID\n" +
                    "Enter 3 to Create Employee and add it to list\n" +
                    "Enter 4 to Edit Employee by ID\n" +
                    "Enter 5 to Delete Employee by ID\n" +
                    "Enter 6 to show list of Employees by range of creation date\n" + 
                    "Enter 7 to sort list of Employees\n" + 
                    "Enter 0 to close\n");
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
                        Console.WriteLine("Enter ID");
                        ShowEmployeeByID(Convert.ToInt32(Console.ReadLine()), filename);
                        break;

                    case "3":
                        string line = "0#" + DateTime.Now.ToString() + "#" + enterData();
                        AddEmployeeToFile(new Employee(line, '#'), filename);
                        break;

                    case "4":
                        Console.WriteLine("Enter ID");
                        SetEmployeeInFile(                  //5) ставим запись 
                            EditEmployee(                   //4) редактируем запись
                                GetEmployeeFromFile(        //3) берем запись
                                    Convert.ToInt32(        //2) конвертим в int
                                        Console.ReadLine()  //1) читаем ID записи
                                        ), filename)
                                ),
                            filename);
                        break;

                    case "5":
                        Console.WriteLine("Enter ID");
                        DeleteEmployeeFromFile(Convert.ToInt32(Console.ReadLine()), filename);
                        break;

                    case "6":
                        Console.WriteLine("Enter Date from");
                        DateTime from = Convert.ToDateTime(Console.ReadLine());
                        Console.WriteLine("Enter Date to");
                        DateTime to = Convert.ToDateTime(Console.ReadLine());

                        Employee[] emps = GetEmployeesDateRange(from, to, filename);
                        for (int i = 0; i < emps.Length; i++)
                            Console.WriteLine(emps[i].ToString(' '));
                        break;

                    case "7":

                        Console.WriteLine("Enter 1 to ascending sort\n" +
                            "Enter 2 to descending sort\n" +
                            "Enter 0 to exit sort menu");
                        string sortChoice = Console.ReadLine();
                        if (sortChoice == "0")
                            break;
                        switch (sortChoice)
                        {
                            case "1":
                                SaveEmpoyeesListIntoFile(GetSortedEmployees(true, filename), filename);
                                break;

                            case "2":
                                SaveEmpoyeesListIntoFile(GetSortedEmployees(false, filename), filename);
                                break;

                            default: break;
                        }

                        break;

                    default: break;
                }
            }
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
            if (File.Exists(filename))
            {
                using (StreamReader sr = new StreamReader(filename))
                {
                    while ((readLine = sr.ReadLine()) != null)
                    {
                        string[] splittedLine = readLine.Split('#');
                        id = Convert.ToInt32(splittedLine[0]);
                    }
                }
            }
            else
                id = 1;
            return id;
        }

        /*static void addLineToFile(string line, string fileName)
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
        */

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
