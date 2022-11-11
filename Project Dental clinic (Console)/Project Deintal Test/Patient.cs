using System;
using System.IO;
namespace Project_Deintal_Test
{
    class Patient : Person
    {
        #region Patient Contractor

        public Patient()
        {
            // Check on file Exists 
            if (!File.Exists("AllPateint.txt"))
            {
                // Write File And Access
                // AppendAllText in File
                File.AppendAllText("AllPateint.txt", PrintLine() + "\n");
                File.AppendAllText("AllPateint.txt", PrintRow(" ", "Name", "Phone", "Age", "Gender", "Address", "Date") + "\n");
                File.AppendAllText("AllPateint.txt", PrintLine() + "\n");
            }
        }
        #endregion

        #region Add Patient

        public void Add_Patient()
        {
            do
            {
                Console.Title = " Add Patient ";
                //Data
                Get_Data();
                string Age, Gender;
                _Name = char.ToUpper(_Name[0]) + _Name.Substring(1);
                Age = Convert.ToString(_Age);
                Gender = Convert.ToString(_Gender);
                string[] Patient_Data = { "Details", _Name, _Phone, Age, Gender, _Address, _Date };
                //Create new File
                File.WriteAllText($"{_Name}.txt", PrintLine() + "\n");
                File.AppendAllText($"{_Name}.txt", PrintRow("Name", "Phone", "Age", "Gender", "Address", "Date") + "\n");
                File.AppendAllText($"{_Name}.txt", PrintLine() + "\n");
                File.AppendAllText($"{_Name}.txt", PrintRow(Patient_Data) + "\n");
                //Add Data in file
                File.AppendAllText("AllPateint.txt", PrintRow(Patient_Data) + "\n");
                File.AppendAllText("AllPateint.txt", PrintLine() + "\n");
                //
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Patient {_Name} has been added successfully !!");
                Console.ForegroundColor = ConsoleColor.White;
                Services();
                Console.WriteLine("Do You Want To Add Anoter Patient (Y or N) ?");

            } while (Console.ReadKey(true).Key == ConsoleKey.Y);

        }
        #endregion

        #region show all Patients

        public void Show_AllPatients() // Report on All Patients Show on Console
        {
            Console.Title = " All Patient Details ";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t╔═════════════════════╗");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t║ All Patient Details ║");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t╚═════════════════════╝");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(File.ReadAllText("AllPateint.txt"));
            Console.WriteLine($"\n\nThere are {NumberOf_Patients()} Patients");

        }
        #endregion

        #region Number Of Patients

        public int NumberOf_Patients()
        {
            if (File.Exists("AllPateint.txt"))
            {
                StreamReader Read = File.OpenText("AllPateint.txt");
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

        #region Update Patient

        public void Update_Patient()
        {
            try
            {
                Console.Title = " Update Patient's Report ";
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("Enter Patient's Name : ");
                string File_Name = Console.ReadLine() + ".txt";
                Console.ForegroundColor = ConsoleColor.White;
                File_Name = char.ToUpper(File_Name[0]) + File_Name.Substring(1);
                if (File.Exists(File_Name))
                {
                    Console.Write("\nDiagnosis of the patient : ");
                    string Diagnosis = Console.ReadLine();
                    Console.Write("\nPharmaceutical : ");
                    string pharmaceutical = Console.ReadLine();
                    File.AppendAllText($"{File_Name}", $"\nDiagnosis of the patient: {Diagnosis} \n\nPharmaceutical : {pharmaceutical}\n");
                }
                else
                {
                    Console.WriteLine($"Sorry, we couldn't find the pati{File_Name.Remove(File_Name.Length - 4)}ent's file");
                }
            }
            catch (IOException ioExp)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Something Went Wrong !!\n{ioExp.Message}");
                Console.ForegroundColor = ConsoleColor.White;
                throw;
            }
        }
        #endregion

        #region Patient Data

        public void Read_Patient()
        {
            try
            {
                Console.Title = " Read Patient's File ";
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("Enter Name of Patient : ");
                string FilePath = Console.ReadLine() + ".txt";
                Console.ForegroundColor = ConsoleColor.White;
                if (File.Exists(FilePath))
                {
                    Console.WriteLine(File.ReadAllText(FilePath));
                }
                else
                {
                    Console.WriteLine($"Sorry, we couldn't find the {FilePath.Remove(FilePath.Length - 4)}'s file");
                }
            }
            catch (IOException ioExp)
            {
                Console.WriteLine($"Something Went Wrong!!\n{ioExp.Message}");
                throw;
            }
        }
        #endregion

        #region Delete Patient

        public void Delete_Patient()
        {
            try
            {
                Console.Title = " Delete Patient's Report ";
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("Enter Name of Patient : ");
                string FilePath = Console.ReadLine() + ".txt";
                Console.ForegroundColor = ConsoleColor.White;
                // Check if file exists with its full path    
                if (File.Exists(Path.Combine(FilePath)))
                {
                    // If file found, delete it    
                    File.Delete(Path.Combine(FilePath));
                    Console.WriteLine("Patient's file has been deleted");
                }
                else Console.WriteLine("Sorry, we couldn't find the patient's file");
            }

            catch (IOException ioExp)
            {
                Console.WriteLine($"Something Went Wrong\n{ioExp.Message}");
            }

        }
        #endregion

        //Console (title /color )
        #region Services
        string[] services = { "..", "Check and preview", "Pediatric Dentistry", "Dental Fillings", "Scaling and Polishing", "Dental Implants", "Orthodontics" };
        int[] cost = { 0, 200, 250, 600, 750, 800, 950 };

        #region Services

        public void Services()
        {
            do
            {
                try
                {
                    Console.Clear();
                    Console.Title = " Our Services ";
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("╔══════════{ Our Services }══╗═{Costs}══════════════╗");
                    Console.WriteLine($"║ 1- Check and preview       ║   {200:C} \t    ║");
                    Console.WriteLine($"║ 2- Pediatric Dentistry     ║   {250:C} \t    ║");
                    Console.WriteLine($"║ 3- Dental Fillings         ║   {600:C} \t    ║");
                    Console.WriteLine($"║ 4- Scaling and Polishing   ║   {750:C} \t    ║");
                    Console.WriteLine($"║ 5- Dental Implants         ║   {800:C} \t    ║");
                    Console.WriteLine($"║ 6- Orthodontics            ║   {950:C} \t    ║");
                    Console.WriteLine("╚════════════════════════════╝══════════════════════╝");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\nChoose your service : ");
                    int Choice = int.Parse(Console.ReadLine());
                    Console.WriteLine($"You Choose {services[Choice]} and it cost {cost[Choice]}");
                    switch (Choice)
                    {
                        case '1':
                            File.AppendAllText("AllServices.txt", "\n200");
                            break;

                        case '2':
                            File.AppendAllText("AllServices.txt", "\n250");
                            break;

                        case '3':
                            File.AppendAllText("AllServices.txt", "\n600");
                            break;

                        case '4':
                            File.AppendAllText("AllServices.txt", "\n2000");
                            break;

                        case '5':
                            File.AppendAllText("AllServices.txt", "\n4000");
                            break;
                        case '6':
                            File.AppendAllText("AllServices.txt", "\n4000");
                            break;
                        default:
                            Console.WriteLine("");
                            break;
                    }
                }
                catch (Exception exp)
                {
                    Console.WriteLine($"Something Went Wrong !!\n{exp.Message}");
                }
                Console.Write("Do you Want To Add Another Service (Y or N) ?\n");
                //Add another service method
            }
            while ((Console.ReadKey(true).Key == ConsoleKey.Y));
        }
        #endregion

        // under fixing  >>>> exception io 
        public static double SumServices()
        {
            {
                StreamReader myReader = new StreamReader("AllServices.txt");
                string line = "";

                while (line != null)
                {
                    line = myReader.ReadLine();
                    //if (line != null)
                    //{
                    //    //Console.WriteLine(line);
                    //}
                }
            }
            string[] lines = File.ReadAllLines(@"AllServices.txt");
            int sum = 0;
            foreach (string line in lines)
                sum = sum + int.Parse(line);
            //Console.WriteLine("Total Money in the System " + sum);
            return sum;
        }
        #endregion
    }
}