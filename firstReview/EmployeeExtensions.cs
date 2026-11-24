namespace Employee_Managment_System
{
    internal static class EmployeeExtensions
    {
        public static bool IsHighSalary(this Employee employee)
        {
            return employee.salary >= 1000;
        }
    }
}