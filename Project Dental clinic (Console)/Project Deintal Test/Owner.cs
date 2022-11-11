using System;
using System.IO;
namespace Project_Deintal_Test
{
    class Owner
    {
        #region TExpinses

        public double TExpinses()
        {

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔═══════════════════════════╗");
            Console.WriteLine("║Enter This Month Expenses  ║");
            Console.WriteLine("╚═══════════════════════════╝");
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("\n\nEnter Electricity bill Coast : ");
            double electricity = double.Parse(Console.ReadLine());
            Console.Write("\nEnter Water bill Coast       : ");
            double Water = double.Parse(Console.ReadLine());
            Console.Write("\nEnter GAS bill Coast         : ");
            double Gas = double.Parse(Console.ReadLine());

           
            Console.Clear();    
            double Total = electricity + Water + Gas;
            return Total;
        }
        #endregion

        #region Staf salary

        public void StafSalary()
        {

            int NurseNum = Nurse.NumberOf_Nurses();
            int NurseSal = NurseNum * 3200;


            int secertaryNum = Secertary.NumberOf_Assistants();
            int SecertarySal = secertaryNum * 3400;

            int DoctorNum = Doctor.NumberOf_Doctors();
            int DoctorSal = DoctorNum * 5000;

            double Expenses = TExpinses();                                               //                    مصروفات المرافق غاز / كهرباء / مياه
            double TotalRevenue = Patient.SumServices();                                      //                  الفلوس اللي داخله العياده

            double TotalStaffSal = SecertarySal + NurseSal + DoctorSal;               //                     رواتب كل الناس


            double TotalExpenses = Expenses + TotalStaffSal;                        //                          كل اللي اتصرف      
            double TotalProfit = TotalRevenue - TotalExpenses;                     //                           أجمالي المكسب او الخساره للمالك

            Console.ForegroundColor = ConsoleColor.Cyan;


            Console.WriteLine(" ╔═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine($"║ The Number Of Doctors : {DoctorNum}\t|\tThe Number Of Nurses : {NurseNum}\t|\tThe Number Of Secertaries  : {secertaryNum} \t ║");
            Console.WriteLine(" ║═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════                                                                                                                                         ║");
            Console.WriteLine($"║ Total Salary Doctors : {DoctorSal}\t|\tTotal Salary Nurses  : {NurseSal}\t|\tTotal Salary Secertaries : {SecertarySal}    \t ║");                
            Console.WriteLine(" ╚═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝\n\n");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔═══════════════════════════════════════════════╗");
            Console.WriteLine($"║Total revenue  = {TotalRevenue:C}  \t\t\t║");
            Console.WriteLine("║═══════════════════════════════════════════════║");
            Console.WriteLine($"║Total Staf number = {secertaryNum + DoctorNum + NurseNum}   \t\t\t║");
            Console.WriteLine("║═══════════════════════════════════════════════║");
            Console.WriteLine($"║Total Staf Salary = {TotalStaffSal:C} \t\t║");
            Console.WriteLine("║═══════════════════════════════════════════════╝═══════════════╗");
            Console.WriteLine($"║Total Expenses ( Electricity , Water , GAS ) = {Expenses:C} \t║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════════╝\n\n");
            Console.ForegroundColor = ConsoleColor.White;


            if (TotalRevenue > TotalExpenses)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("╔════════════════════════════════════════════════════════╗");
                Console.WriteLine($"║ Our clinics made a profit {TotalProfit:C} this month   \t ║");
                Console.WriteLine("╚════════════════════════════════════════════════════════╝");
                Console.ForegroundColor = ConsoleColor.White;

            }
          
            else if (TotalRevenue < TotalExpenses)

            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("╔════════════════════════════════════════════════════════╗");
                Console.WriteLine($"║  Our clinics made a loss {Math.Abs(TotalProfit):C} this month  \t ║");
                Console.WriteLine("╚════════════════════════════════════════════════════════╝");
                Console.ForegroundColor = ConsoleColor.White;

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(" ╔═══════════════════════════════════════╗");
                Console.WriteLine($"║ There is no loss or Profit This Month ║");
                Console.WriteLine(" ╚═══════════════════════════════════════╝");
                Console.WriteLine("There is no loss or Profit This Month");
                Console.ForegroundColor = ConsoleColor.White;

            }
        }

        #endregion


        public static void RemovePerson(string path, string Role ,string Name)
        {
            Console.Title = $"Delete {Role}";

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.Write($" Enter The Name of {Role} you want to Delete : ");
            string Delete = Console.ReadLine();
            string strOldText;
            string n = "";
            StreamReader sr = File.OpenText(path);
            while ((strOldText = sr.ReadLine()) != null)
            {
                if (!strOldText.Contains(Delete))
                {
                    n += strOldText + Environment.NewLine;
                }
            }
            sr.Close();
            File.WriteAllText(path, n);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($" [ - ] {Role} {Name}  has been Deleted Successfully");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

   
}