using System;
using System.IO;
namespace Project_Deintal_Test
{
    class Secertary : Person
    {
        ///done
        #region Secertary Contractor

        public Secertary()
        {
            // Check on file Exists 
            if (!File.Exists("AllAssistants.txt"))
            {
                // Write File And Access
                // AppendAllText in File
                File.AppendAllText("AllAssistants.txt", PrintLine() + "\n");
                File.AppendAllText("AllAssistants.txt", PrintRow(" ", "Name", "Phone", "Age", "Gender", "Address", "Salary", "Date") + "\n");
                File.AppendAllText("AllAssistants.txt", PrintLine() + "\n");
            }
        }
        #endregion

        #region Add Assistant

        public void Add_Assistant()
        {
            do
            {
                Console.Title = " Add Secertary ";
                //get Assistant Data .
                Get_Data();               //Store Method from Person
                string Age, Gender, Salary;
                _Name = char.ToUpper(_Name[0]) + _Name.Substring(1); //First Character uppercase
                Age = Convert.ToString(_Age);
                Gender = Convert.ToString(_Gender);
                Salary = Convert.ToString($"{3400:C}");
                string[] Assistant_Data = { "Details", _Name, _Phone, Age, Gender, _Address, Salary, _Date };
                //Add Assisstant's Data in file .
                File.AppendAllText("AllAssistants.txt", PrintRow(Assistant_Data) + "\n");
                File.AppendAllText("AllAssistants.txt", PrintLine() + "\n");
                //
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Assistant {_Name} has been added successfully !!");
                Console.ForegroundColor = ConsoleColor.White;
                //Add Another Assistant .
                Console.WriteLine("Do You Want To Add Anoter Assistants (Y or N) ?");
            } while (Console.ReadKey(true).Key == ConsoleKey.Y);

        }
        #endregion

        #region show all Assistants

        public void Show_AllAssistants() // All Assistant in System
        {
            Console.Title = " All Secertaries Details ";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t╔═════════════════════════╗");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t║ All Secertaries Details ║");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t╚═════════════════════════╝");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(File.ReadAllText("AllAssistants.txt"));
            Console.WriteLine($"\n\nThere are {NumberOf_Assistants()} Assistants");

        }
        #endregion

        #region Secertary Mangement

        public void Secertary_Mangement()
        {
            do
            {
                Console.Clear();
                Console.Title = " Secertary Mangement ";
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════╗");
                Console.WriteLine("║ 1-Add Secertary    |   2-Show All Secertary    |   3-Delete Secertary ║");
                Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════╝");
                Console.ForegroundColor = ConsoleColor.White;
                try
                {
                    Console.Write("\nChoose Valid Process Number : ");
                    char Secertary_Process = char.Parse(Console.ReadLine());

                    switch (Secertary_Process)
                    {
                        case '1':
                            Console.Clear();
                            Add_Assistant();
                            break;

                        case '2':
                            Console.Clear();
                            Show_AllAssistants();
                            break;

                        case '3':
                            Console.Clear();
                            Owner.RemovePerson("AllAssistants.txt", "Secertary", _Name);

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
                Console.WriteLine("Do You Want To Do Another Process In Secertary Mangement (Y or N) ?");
            } while (Console.ReadKey(true).Key == ConsoleKey.Y);
        }
        #endregion

        #region Number Of Assistants

        public static int NumberOf_Assistants() // Number of Assistants in System
        {
            if (File.Exists("AllAssistants.txt"))
            {
                StreamReader Read = File.OpenText("AllAssistants.txt");
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