using System;
using System.IO;

namespace Project_Deintal_Test
{
    class Doctor : Person
    {
        ///done
        private static string Qualifications;
        public string _Quali
        {
            get { return Qualifications; }
            set { Qualifications = value; }
        }
        #region Doctor Contractor

        public Doctor()
        {
            // Check on file Exists 
            if (!File.Exists("AllDoctors.txt"))
            {
                // Write File And Access
                // AppendAllText in File
                File.AppendAllText("AllDoctors.txt", PrintLine() + "\n");
                File.AppendAllText("AllDoctors.txt", PrintRow(" ", "Name", "Phone", "Age", "Gender", "Address", "Salary", "Date", "Qualifications") + "\n");
                File.AppendAllText("AllDoctors.txt", PrintLine() + "\n");
            }
        }
        #endregion

        #region Add Doctor

        public void Add_Doctor()
        {
            do
            {
                Console.Title = " Add Doctor ";
                //Data
                Get_Data();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Enter Qualifications : ");
                try
                {
                    _Quali = Console.ReadLine();
                }
                catch (Exception exp)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Something Went Wrong !! \n{exp.Message}");
                    Console.ForegroundColor = ConsoleColor.White;
                    throw;
                }
                Console.ForegroundColor = ConsoleColor.White;
                string Age, Gender, Salary;
                _Name = char.ToUpper(_Name[0]) + _Name.Substring(1);
                Age = Convert.ToString(_Age);
                Gender = Convert.ToString(_Gender);
                Salary = Convert.ToString($"{5000:C}");
                string[] Doctor_Data = { "Details", _Name, _Phone, Age, Gender, _Address, Salary, _Date, _Quali };
                //Add Doctor's Data in file
                File.AppendAllText("AllDoctors.txt", PrintRow(Doctor_Data) + "\n");
                File.AppendAllText("AllDoctors.txt", PrintLine() + "\n");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Dr.{_Name} has been added successfully !!");
                Console.ForegroundColor = ConsoleColor.White;
                // Add Another Doctor
                Console.WriteLine("Do You Want To Add Anoter Doctor (Y or N) ?");
            } while (Console.ReadKey(true).Key == ConsoleKey.Y);

        }
        #endregion

        #region show all Doctors

        public void Show_AllDoctors() // Report on All Doctors Show on Console
        {
            Console.Title = "All Doctors Details";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t╔═════════════════════╗");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t║ All Doctors Details ║");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t╚═════════════════════╝");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(File.ReadAllText("AllDoctors.txt"));
            Console.WriteLine($"\n\nThere are {NumberOf_Doctors()} Doctors");

        }
        #endregion

        #region Doctor Mangement

        public void Doctor_Mangement()
        {
            do
            {
                Console.Clear();
                Console.Title = " Doctor Mangement ";
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("╔═════════════════════════════════════════════════════════════╗");
                Console.WriteLine("║ 1-Add Doctor   |   2-Show All Doctors  |   3-Delete Doctors ║");
                Console.WriteLine("╚═════════════════════════════════════════════════════════════╝");
                Console.ForegroundColor = ConsoleColor.White;
                try
                {
                    Console.Write("\nChoose Valid Process Number : ");
                    char Doctor_Process = char.Parse(Console.ReadLine());

                    switch (Doctor_Process)
                    {
                        case '1':
                            Console.Clear();
                            Add_Doctor();
                            break;

                        case '2':
                            Console.Clear();
                            Show_AllDoctors();
                            break;

                        case '3':
                            Console.Clear();
                            Owner.RemovePerson("AllDoctors.txt","Doctor",_Name);
                            break;

                        default:
                            Console.WriteLine("Enter Valid Number");
                            break;
                    }
                }
                catch (Exception exp)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Something Went Wrong !!\n{exp.Message}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine("Do You Want To Do Another Process In Doctor Mangement (Y or N) ?");
            } while (Console.ReadKey(true).Key == ConsoleKey.Y);
        }
        #endregion

        #region Number Of Doctors

        public static int NumberOf_Doctors()
        {
            if (File.Exists("AllDoctors.txt"))
            {

                StreamReader Read = File.OpenText("AllDoctors.txt");
                int Count = 0;
                int LineNumber = 0;
                while (!Read.EndOfStream)
                {
                    string line = Read.ReadLine();
                    LineNumber++;
                    int position = line.IndexOf("Details");
                    if (position != -1)
                    {
                        Count++;
                    }
                }
                Read.Close();
                return Count;
            }
            else
            {
                return 0;
            }
        }
        #endregion
    }
}