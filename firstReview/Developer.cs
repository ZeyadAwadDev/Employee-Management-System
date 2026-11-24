

namespace Employee_Managment_System
{
        public class Developer : Employee
        {
            public string ProgrammingLanguage { get; private set; }
            public Developer(int id, string name, double salary, string programinglanguage) : base(id, name, salary)
            {
                if (string.IsNullOrWhiteSpace(programinglanguage))
                    throw new ArgumentException("programing language cannot be null or empty",nameof(programinglanguage));
                ProgrammingLanguage = programinglanguage;
            }
            public override void PrintEmployeeInfo()
            {
                base.PrintEmployeeInfo() ;
                Console.WriteLine($"Programming Language is {ProgrammingLanguage}");
            }

        }
    }

