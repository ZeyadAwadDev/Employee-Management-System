
using Humanizer;

namespace Employee_Managment_System
{
        public class Employee:IEmployeeAction,IComparable<Employee>
        {
            private int _id;
            private string _name;
            private double _salary;

            public Employee(int id, string name, double salary, EmployeeState state)
            {
                if(id<=0)
                    throw new ArgumentOutOfRangeException(nameof(id), "id must be grater than zero");
                _id = id;
                if (string.IsNullOrWhiteSpace(name)) { 
                throw new ArgumentException("Name cannot be null, empty, or whitespace.", nameof(name));
                }
               
                _name = name;
                if(salary<0)
                    throw new  ArgumentOutOfRangeException(nameof(salary));
                _salary = salary;
                this.state = state;
            }
            public Employee(int id, string name, double salary):this (id, name,salary,EmployeeState.Active) {
                

               
            }

            public EmployeeState state { get;private set; }
            public int ID
            {
                get { return _id; }
            }
            public double salary
            {
                get { return _salary; }
                private set { _salary = value; }
            }
        public string Name
        {
            get{return _name; }
        }
          
            public double CalculateSalary(double bouns)
            {
                return _salary + bouns;
            }
            public virtual void PrintEmployeeInfo()
            {

                Console.WriteLine($"Employee Id :{_id}\n Employee " +
                    $"Name:{_name}\n salay is{_salary}\n Final SAlary:{CalculateSalary(150)}\n State:{state.Humanize()} ");
            }
            public override string ToString()
            {
                return $" Id:{_id}Name: {_name} salary:{_salary}";
            }
            public Employee UpdateSalary(double newsalary)
            {
                if(newsalary<0)
                    throw new ArgumentOutOfRangeException(nameof(newsalary));
                salary = newsalary;
                return this ;
            }
            public Employee ChangeState(EmployeeState newState)
            {
                if(state ==EmployeeState.Resigned)
                    throw new InvalidOperationException(nameof(newState)); 

                state = newState;
                return this ;
            }

             public int  CompareTo(Employee? other)
            {
                if(other is null) 
                    return 1;
                return other.salary.CompareTo(salary);

            }
            public override bool Equals(object? obj)
            {
                if (obj is Employee other)
                {
                    return ID == other.ID;
                }

                return false;
            }

            public override int GetHashCode()
            {
                return ID.GetHashCode();
            }
           
        }

    }

