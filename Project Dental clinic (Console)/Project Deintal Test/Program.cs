using System;
using System.IO;
namespace Project_Deintal_Test
{
    internal class Program
    {
        #region About us
        public static void About_us()
        {
            Console.Title = "About us";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t\t\t\t\t╔══════════════════════════════════╗");
            Console.WriteLine("\t\t\t\t\t║     Brief about our Clinics      ║");
            Console.WriteLine("\t\t\t\t\t╚══════════════════════════════════╝");

            Console.WriteLine(" We know that a healthy mouth—especially the teeth, lips and tongue—is essential for speech and affects\n our ability to taste, chew, and digest foods." +
                " We also know that poor oral health—such as chronic inflammation\n from gum disease—has been associated with heart disease, blockages, and strokes." +
                "\n Research even suggests that a healthy mouth may" +
                " help prevent pre-term births and low birth-weight babies," +
                "\n and help us prevent memory loss in later years of life.");
            Console.WriteLine();
            Console.WriteLine("We are committed to helping you maintain your oral health as an integral part of your overall health and wellness.");
            Console.ForegroundColor = ConsoleColor.White;
        }   //About Our Clinic
        #endregion

        static void Main(string[] args)
        {
            // To Add Variable : 
            #region Variables
            Patient P = new Patient();
            Nurse N = new Nurse();
            Secertary s = new Secertary();
            Doctor D = new Doctor();
            Owner O = new Owner();
            #endregion



            do
            {
                Console.Clear();
                About_us();

                string[] User = new string[4] { "doc", "sec", "nurse", "owner" };
                string[] Pass = new string[4] { "123", "123", "123", "123" };
                login Account = new login(); //still in test
                //login.Create_Account();
                try
                {

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\n\n\t\t\t\t\t ------------   Login Account   ------------        \n");
                    Console.Write("\n\t\t\t\t\t * Enter UserName : ");
                    string user = Console.ReadLine();

                    Console.Write("\n\t\t\t\t\t * Enter Password : ");
                    string pass = Console.ReadLine();

                    char ch = login.Get_Type_login(user, pass);

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Clear();
                    if (ch=='D')
                    {
                        #region Doctor

                        do
                        {
                            Console.Clear();
                            Console.Title = "Doctor";
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
                            Console.WriteLine("║ 1- ADD Patient |   2- update Patient   |   3- Delete patient   |   4- Show All Patient    |   5- Show Patient Report  ║");
                            Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(" Choose Your Proccess : ");
                            char choice = char.Parse(Console.ReadLine());

                            switch (choice)
                            {
                                case '1':
                                    Console.Clear();
                                    P.Add_Patient();
                                    break;

                                case '2':
                                    Console.Clear();
                                    P.Update_Patient();
                                    break;

                                case '3':
                                    Console.Clear();
                                    P.Delete_Patient();
                                    Owner.RemovePerson("AllPateint.txt", "Patient", P._Name);
                                    break;

                                case '4':
                                    Console.Clear();
                                    P.Show_AllPatients();
                                    break;

                                case '5':
                                    Console.Clear();
                                    P.Read_Patient();
                                    break;

                                default:
                                    Console.WriteLine(" Please Enter Valid Choice");
                                    break;
                            }
                            Console.WriteLine("Do You Want To Do Anoter Proccess (Y or N) ?");
                        } while (Console.ReadKey(true).Key == ConsoleKey.Y);
                        #endregion
                    }
                    else if (ch == 'S')
                    {
                        #region Secertary

                        do
                        {
                            Console.Clear();
                            Console.Title = "Secertary";
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════════════════════╗");
                            Console.WriteLine("║ 1-ADD Patient  |   2- Print Patient Report |   3- Show All Patient |   4- Delete patient ║");
                            Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════════════════════╝");
                            Console.ForegroundColor = ConsoleColor.White;

                            try
                            {
                                Console.Write(" Choice Proccess : ");
                                char choice = char.Parse(Console.ReadLine());

                                switch (choice)
                                {
                                    case '1':
                                        Console.Clear();
                                        P.Add_Patient();
                                        break;

                                    case '2':
                                        Console.Clear();
                                        P.Read_Patient();
                                        break;

                                    case '3':
                                        Console.Clear();
                                        P.Show_AllPatients();
                                        break;

                                    case '4':
                                        Console.Clear();
                                        P.Delete_Patient();
                                        break;

                                    default:
                                        Console.WriteLine(" Please Enter Valid Choice");
                                        break;
                                }
                            }
                            catch (Exception exp)
                            {
                                Console.WriteLine($"Something Went Wrong !!!\n{exp.Message}");
                            }
                            Console.WriteLine("Do You Want To Do Anoter Proccess (Y or N) ?");
                        } while (Console.ReadKey(true).Key == ConsoleKey.Y);
                        #endregion
                    }
                    else if (ch == 'O')
                    {
                        #region Owner

                        do
                        {
                            Console.Clear();

                            Console.Title = "Owner";
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("╔═════════════════════════════════════════════════════════════════════════════════════════════════════╗");
                            Console.WriteLine("║ 1-Doctor   |   2-Secertary |   3-Nurse |   4- Generate Mangement Report    |   5- Account Mangement ║");
                            Console.WriteLine("╚═════════════════════════════════════════════════════════════════════════════════════════════════════╝");
                            Console.ForegroundColor = ConsoleColor.White;

                            Console.Write(" Choice Proccess : ");
                            char choice = char.Parse(Console.ReadLine());

                            switch (choice)
                            {

                                case '1':
                                    D.Doctor_Mangement();
                                    break;

                                case '2':
                                    s.Secertary_Mangement();
                                    break;

                                case '3':
                                    N.Nurse_Mangement();
                                    break;
                                case '4':

                                    Console.Clear();
                                    O.StafSalary();
                                    break;
                                case '5':
                                    login.Create_Account();
                                    break;

                            }
                            Console.WriteLine("Do You Want To Go Back To Main Owner Page (Y or N)");

                        } while (Console.ReadKey(true).Key == ConsoleKey.Y);
                        #endregion
                    }
                    else if (ch == 'N')
                    {
                        #region Nurse

                        do
                        {
                            Console.Clear();

                            Console.Title = "Nurse";
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("╔════════════════════════════════════════════════════╗");
                            Console.WriteLine("║ 1- Patient Examination |  2- Add Laboratory Result ║");
                            Console.WriteLine("╚════════════════════════════════════════════════════╝");
                            Console.ForegroundColor = ConsoleColor.White;

                            Console.Write(" Choice Proccess : ");
                            char choice = char.Parse(Console.ReadLine());

                            switch (choice)
                            {
                                case '1':
                                    Console.Clear();
                                    N.Examination();
                                    break;

                                case '2':
                                    Console.Clear();
                                    N.AddLaboratoryResult();
                                    break;

                                default:
                                    Console.WriteLine(" Please Enter Valid Choice");
                                    break;
                            }
                            Console.WriteLine("Do You Want To Do Anoter Proccess (Y or N)");
                        } while (Console.ReadKey(true).Key == ConsoleKey.Y);
                        #endregion
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Please Check your Email or Password ");
                    }
                    Console.WriteLine("Do You Want To Restart Program ? ");
                }
                catch (Exception exp)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Something Went Wrong!!\n{exp.Message}");
                    Console.ForegroundColor = ConsoleColor.White;
                    throw;

                }
            } while (Console.ReadKey(true).Key == ConsoleKey.Y);
        }
    }
}