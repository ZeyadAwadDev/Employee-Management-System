namespace Employee_Managment_System
{
        public class Manager : Employee
        {
            public int TeamSize {  get;private set; }
            public Manager(int id,string name,double salry,int teamsize):base(id,name,salry )
            {
                if(teamsize>0)
                TeamSize = teamsize;
                else
                    throw new ArgumentOutOfRangeException(nameof(teamsize));
            }
            public override void PrintEmployeeInfo()
            {
                base.PrintEmployeeInfo();
                Console.WriteLine($"Team Size is {TeamSize}");
            }
        }
    }
