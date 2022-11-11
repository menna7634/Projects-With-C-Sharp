using System;
using System.IO;

namespace Project_Deintal_Test
{
    sealed class Nurse : Person
    {
        ///done
        #region Nurse Contractor

        public Nurse()
        {
            // Check on file Exists 
            if (!File.Exists("AllNurse.txt"))
            {                // Write File And Access
                // AppendAllText in File
                File.AppendAllText("AllNurse.txt", PrintLine() + "\n");
                File.AppendAllText("AllNurse.txt", PrintRow(" ", "Name", "Age", "Address", "Phone", "Salary", "Date") + "\n");
                File.AppendAllText("AllNurse.txt", PrintLine() + "\n");
            }
        }
        #endregion

        #region Add Nurse

        public void Add_Nurse()  // Set New Nurse 
        {
            do
            {
                //Data 
                Console.Title = " Add Nurse ";
                Get_Data();
                string Age, Gender, Salary;
                _Name = char.ToUpper(_Name[0]) + _Name.Substring(1);
                Age = Convert.ToString(_Age);
                Gender = Convert.ToString(_Gender);
                Salary = Convert.ToString($"{3200:C}");
                string[] Nurse_Data = { "Details", _Name, _Phone, Age, Gender, _Address, Salary, _Date };
                //Add Data in file
                File.AppendAllText("AllNurse.txt", PrintRow(Nurse_Data) + "\n");
                File.AppendAllText("AllNurse.txt", PrintLine() + "\n");
                //
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Nurse {_Name} has been added successfully !!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Do You Want To Add Anoter Assistants (Y or N) ?");
            } while (Console.ReadKey(true).Key == ConsoleKey.Y);
        }
        #endregion

        #region show all Nurses

        public void Show_AllNurse() // Report on All Nurse Show on Console
        {
            Console.Title = " All Nurses Details ";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t╔════════════════════╗");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t║ All Nurses Details ║");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t╚════════════════════╝");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(File.ReadAllText("AllNurse.txt"));
        }
        #endregion

        #region Number of Nurses

        public static int NumberOf_Nurses()
        {
            //DocumentCore DC = DocumentCore.Load("AllNurse.txt");
            //string search = "Name";
            //Regex regex = new Regex("(?i)" + search);
            //int count = DC.Content.Find(regex).Count();
            //return count;
            if (File.Exists("AllNurse.txt"))
            {

                StreamReader Read = File.OpenText("AllNurse.txt");
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

        #region Nurse Mangement 

        public void Nurse_Mangement()
        {
            do
            {
                Console.Clear();
                Console.Title = " Nurse Mangement ";
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
                Console.WriteLine("║ 1-Add Nurse    |   2-Show All Nuurses  |   3-Delete Nurse ║");
                Console.WriteLine("╚═══════════════════════════════════════════════════════════╝");

                Console.ForegroundColor = ConsoleColor.White;
                try
                {
                    Console.Write("\nChoose Valid Process Number : ");
                    char Nurse_Process = char.Parse(Console.ReadLine());

                    switch (Nurse_Process)
                    {
                        case '1':
                            Console.Clear();
                            Add_Nurse();
                            break;

                        case '2':
                            Console.Clear();
                            Show_AllNurse();
                            break;

                        case '3':
                            Console.Clear();
                            Owner.RemovePerson("AllNurse.txt", "Nurse", _Name);
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
                Console.WriteLine("Do You Want To Do Another Process In Nurse Mangement (Y or N) ?");
            } while (Console.ReadKey(true).Key == ConsoleKey.Y);
        }
        #endregion

        // Console (title / color / Mergs with lab)
        #region Examination (not done !!)
        public void Examination()
        {
            Console.Write("Enter Patient's Name : ");
            string File_Name = Console.ReadLine() + ".txt";
            if (File.Exists(File_Name))
            {
                Console.WriteLine("Does the patient suffer from chronic diseases ( Y or N ) ? ");
                if (Console.ReadKey(true).Key == ConsoleKey.Y)
                {
                    do
                    {
                        Console.WriteLine("1- Blood pressure \n2- Diabetes");   //need edit
                        Console.Write("Chronic Diseases :  ");

                        char Chronic_Diseases = char.Parse(Console.ReadLine());
                        switch (Chronic_Diseases)
                        {
                            case '1':
                                File.AppendAllText($"{File_Name}", $"\nChronic Diseases : The patient suffers from ( Blood pressure  ) \n");
                                Console.Write("Blood pressure Measurment :  ");
                                string Chronic_Diseases1 = Console.ReadLine();
                                File.AppendAllText($"{File_Name}", $"\nBlood pressure Measurment : {Chronic_Diseases1} \n");
                                break;

                            case '2':
                                File.AppendAllText($"{File_Name}", $"\nChronic Diseases : The patient suffers from ( Diabetes ) \n");
                                Console.Write("Diabetes  Measurment :  ");
                                string Chronic_Diseases2 = Console.ReadLine();
                                File.AppendAllText($"{File_Name}", $"\nDiabetes  Measurment : {Chronic_Diseases2} \n");
                                break;


                        }
                        Console.WriteLine("Do You Want To Do Anoter Proccess (Y or N)");
                    } while (Console.ReadKey(true).Key == ConsoleKey.Y);
                }
                else if (Console.ReadKey(true).Key == ConsoleKey.N)
                {
                    File.AppendAllText($"{File_Name}", $"\n\n Chronic Diseases : The {File_Name.Remove(File_Name.Length - 4)} does not suffer from chronic diseases \n");
                }
            }
            else
            {
                File_Name = char.ToUpper(File_Name[0]) + File_Name.Substring(1);
                Console.WriteLine($"Sorry, we couldn't find {File_Name.Remove(File_Name.Length - 4)}'s report ");
            }
        }
        #endregion  
        //merger with Laboratory

        #region laboratory 

        public void AddLaboratoryResult()
        {
            Console.WriteLine("\n\t\t\t\t\t -------------------------------------\n");

            Console.Write("\n\t\t\t\t\tEnter Patient's Name : ");
            string File_Name = Console.ReadLine() + ".txt";
            if (File.Exists($"{File_Name}"))
            {
                Console.Clear();
                do
                {
                    Console.WriteLine("\n\t\t\t\t\t -------------------------------------------------------------------------------------------\n");
                    Console.WriteLine("\n\t\t\t\t\t1-INR Blood Test\n\t\t\t\t\t2-Comblete Blood Count Test (CBC)\n\t\t\t\t\t3- Calcium Test ");
                    Console.WriteLine("\n\t\t\t\t\t -------------------------------------------------------------------------------------------\n");
                    Console.Write("\n\t\t\t\t\tChoose the type of lab analysis : ");
                    char Chronic_Diseases = char.Parse(Console.ReadLine());

                    switch (Chronic_Diseases)
                    {
                        case '1':
                            Console.Clear();
                            Console.Write(" \n\t\t\t\t\tBlood clotting Rate :  ");
                            double Rate = double.Parse(Console.ReadLine());
                            File.AppendAllText($"{File_Name}", $"\nBlood clotting Rate:  {Rate} \n");
                            break;

                        case '2':
                            Console.Clear();
                            Console.Write(" \n\t\t\t\t\t-------Result of Comblete Blood Count Test (CBC)--------\n ");
                            Console.Write("\n\t\t\t\t\t Red blood cell count : ");
                            double RBC = double.Parse(Console.ReadLine());
                            Console.Write("\n\t\t\t\t\t Hemoglobin :  ");
                            double Hemo = double.Parse(Console.ReadLine());
                            Console.Write("\n\t\t\t\t\t White blood cell count : ");
                            double WBC = double.Parse(Console.ReadLine());
                            Console.Write("\n\t\t\t\t\t Platelet count :  ");
                            double PC = double.Parse(Console.ReadLine());
                            Console.Write("\n\t\t\t\t\t Hematocrit :  ");
                            double Hema = double.Parse(Console.ReadLine());
                            File.AppendAllText($"{File_Name}", $"\nRed blood cell count:  {RBC} trillion cells/L \nHemoglobin:  {Hemo} grams/dL\nWhite blood cell count :  {WBC} billion cells/L \nPlatelet count :  {PC} billion/L \nHematocrit :  {Hema} percent \n\n");
                            Console.Write(" \n\t\t\t\t\t--------------------------------------------------------\n ");
                            break;

                        case '3':
                            Console.Clear();
                            Console.Write("\n\t\t\t\t\t Amount Of Calcium :  ");
                            double AOC = double.Parse(Console.ReadLine());
                            File.AppendAllText($"{File_Name}", $"\nAmount Of Calcium :  {AOC} mg/dL \n");
                            break;
                        default:
                            Console.WriteLine("Choose Process Number");

                            break;
                    }
                    Console.WriteLine("Do You Want To Do Anoter Proccess (Y or N)");
                } while (Console.ReadKey(true).Key == ConsoleKey.Y);
            }
            else
            {
                Console.WriteLine($"Sorry, we couldn't find the {File_Name.Remove(File_Name.Length - 4)}'s file");
            }
        }

        #endregion
    }
}