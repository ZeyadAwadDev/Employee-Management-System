
namespace Employee_Managment_System
{
    
    
        public class Auditor : IEmployeeAction
        {
            public void PrintEmployeeInfo()
            {
                Console.WriteLine("Auditor is reviewing employee Record");
            }
        }
    }

