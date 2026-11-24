using Humanizer;

namespace Employee_Managment_System
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            
                // Load employees from file
                List<Employee> employees = LoadEmployees();

                // Create Dictionary
                Dictionary<int, Employee> employeeDictionary =
                    employees.ToDictionary(emp => emp.ID);

                // Display employees
                foreach (var employee in employees)
                {
                    employee.PrintEmployeeInfo();
                }
            }
        
        public static IEnumerable<Employee> GetActiveEmplyees(List<Employee> employees)
        {
            foreach (Employee employee in employees)
            {
                if (employee.state == EmployeeState.Active)
                {
                    yield return employee;
                }
            }
        }
        public static int FindEmployeeBySalary(List<Employee> employees, double Salary)
        {
            int Count = 0;
            bool found = false;
            foreach (Employee employee in employees)
            {

                if (employee.salary == Salary)
                {
                    Console.WriteLine(employee);
                    found = true;
                    Count++;
                }

            }
            if (!found)
            {
                Console.WriteLine("Not found Employee you salary Equal requirment salary");
            }
            return Count;
        }
        public static void UpdateEmployeeSalary(List<Employee>employees,Dictionary<int, Employee> employeeDictionary, int id, double newsalary)
        {
            Employee? test = FindEmployeeById(employeeDictionary, id);
            if (test != null)
            {
                test.UpdateSalary(newsalary);
                SaveEmployee(employees);
            }
            else
            {
                Console.WriteLine("Employee not found");
            }

        }
        public static void DeleteEmployee(List<Employee> employees, Dictionary<int, Employee> employeeDictionary, int id)
        {
            if (employeeDictionary.TryGetValue(id, out Employee? employee))
            {
                employees.Remove(employee);
                employeeDictionary.Remove(employee.ID);
                SaveEmployee(employees);
                Console.WriteLine("Employee deleted Successfully");
            }

            else
            {
                Console.WriteLine("Employee not found");
            }
        }
        public static Employee? FindHighestSalary(List<Employee> employees)
        {
            if (employees == null || employees.Count == 0)
                return null;

            Employee? highst = null;
            foreach (var emp in employees)
            {

                if (emp.state != EmployeeState.Resigned)
                {
                    if (highst == null || emp.salary > highst.salary)
                    {
                        highst = emp;
                    }
                }

            }
            return highst;

        }
        public static Employee? FindEmployeeById(Dictionary<int, Employee> employeeDictionary, int id)
        {


            if (employeeDictionary.TryGetValue(id, out Employee? value))
            {
                return value;
            }
            else
            {

                return null;
            }
        }


        public static void AddEmployee(List<Employee> employees, Dictionary<int, Employee> employeeDictionary, Employee newEmployee)
        {

            if (employeeDictionary.ContainsKey(newEmployee.ID))
            {
                Console.WriteLine("Employee is already is exist");
                return;
            }

            employees.Add(newEmployee);
            employeeDictionary.Add(newEmployee.ID, newEmployee);
            SaveEmployee(employees);
            Console.WriteLine("Employee Add Successfully");
        }
        public static void SaveEmployee(List<Employee> employees)
        {
            using (var sw = new StreamWriter("employees.txt"))
            {
                foreach (var employee in employees)
                {

                    if (employee is Developer developer)
                    {
                        sw.WriteLine($"{employee.ID}|{employee.salary}|{employee.Name}|" +
                            $"{employee.state}|Developer|{developer.ProgrammingLanguage}");
                    }
                    else if (employee is Manager manager)
                    {
                        sw.WriteLine($"{employee.ID}|{employee.salary}|{employee.Name}|" +
                            $"{employee.state}|Manager|{manager.TeamSize}");
                    }
                    else
                    {
                        sw.WriteLine($"{employee.ID}|{employee.salary}|{employee.Name}|{employee.state}|Employee");
                    }
                }
            }
        }
        public static List<Employee> LoadEmployees()
        {
            List<Employee> employees = new List<Employee>();
            if (!File.Exists("employees.txt"))
            {
                return employees;
            }
            using (var sr = new StreamReader("employees.txt"))
            {
                string? line;
                while ((line = sr.ReadLine()) != null)
                {
                 string[]parts =line.Split("|");
                    int id = int.Parse(parts[0]);
                    double salary=double.Parse(parts[1]);
                    string name=parts[2];
                    EmployeeState state=Enum.Parse<EmployeeState>(parts[3]);
                    Employee loadedEmployee;
                    if (parts[4] == "Developer")
                    {
                        loadedEmployee=new Developer(id, name, salary,parts[5]);
                    }
                    else if(parts[4] == "Manager")
                    {
                        loadedEmployee=new Manager(id,name,salary,int.Parse(parts[5]));
                    }
                    else
                    {
                        loadedEmployee = new Employee(id, name, salary);
                    }
                    loadedEmployee.ChangeState(state);
                    employees.Add(loadedEmployee);
                }
            }
            return employees;
        }
    }
}
