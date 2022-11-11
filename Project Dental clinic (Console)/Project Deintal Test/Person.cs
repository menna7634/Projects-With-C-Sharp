using System;
namespace Project_Deintal_Test
{
    #region Enum (Type)
    enum _Gender
    {
        Male = 1,
        Female
    }
    #endregion

    class Person
    {
        ///done
        #region Person Contractor
        /*public Person()
        {

        }
        public Person(string Name, string Phone, byte Age, double Salary, _Gender Gender, DateTime Date, string Address)
        {
            this.ID = ++Number;
            this.Name = Name;
            this.Phone = Phone;
            this.Age = Age;
            this.Gender = Gender;
            this.Salary = Salary;
            this._Date = Date;
            this.Address = Address;
        }*/
        #endregion

        //fixing ID later
        //private int ID = 1;
        //private static int Number = 0;
        //public int _ID
        //{
        //    get { return ID; }
        //    set { ID = value; }
        //}

        #region Class Data

        private string Name;
        public string _Name
        {
            get { return Name; }
            set { Name = value; }
        }
        private string Phone;
        public string _Phone
        {
            get { return Phone; }
            set { Phone = value; }
        }
        private byte Age;
        public byte _Age
        {
            get { return Age; }
            set { Age = value; }
        }
        private double Salary;
        public double _Salary
        {
            get { return Salary; }
            set { Salary = value; }
        }
        private _Gender Gender;
        public _Gender _Gender
        {
            get { return Gender; }
            set { Gender = value; }
        }
        private string Address;
        public string _Address
        {
            get { return Address; }
            set { Address = value; }
        }
        public string _Date = Date();
        public static string Date()
        {
            DateTime todaysDate = DateTime.UtcNow;
            string dateString = String.Format("{0:dd/MM/yyyy}", todaysDate);
            return dateString;
        }



       
        #endregion

        #region Get Data

        public void Get_Data()
        {
            try
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n════════════════════{  INPUT DATA  }══════════════════════════════\n");
                Console.Write("\nEnter Your Name : ");
                _Name = Console.ReadLine();
                Console.Write("\nEnter Your Phone : ");
                _Phone = Console.ReadLine();
                Console.Write("\nEnter Your Age : ");
                _Age = byte.Parse(Console.ReadLine());
                Console.Write($"Gender ( {_Gender.Male} | {_Gender.Female} ) : ");
                if (Console.ReadKey(false).Key == ConsoleKey.M)
                {
                    _Gender = _Gender.Male;
                }
                else
                {
                    _Gender = _Gender.Female;
                }
                Console.Write("\nEnter Your Address : ");
                _Address = Console.ReadLine();
                _Date = Date();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n");
            }
            catch (Exception exp)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Something Went Wrong !!\n{exp.Message}");
                Console.ForegroundColor = ConsoleColor.White;
                throw;
            }

        }
        #endregion

        #region Table

        //  Create Table In File
        private int tableWidth = 180;
        public string PrintLine() // Title draw
        {

            return new string('═', tableWidth);
        }
        public string PrintRow(params string[] columns) // Put Title
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "║";

            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "║";
            }
            //Console.WriteLine(row);
            return row;
        }

        public string AlignCentre(string text, int width) // Put Data If found
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }
        #endregion

        /* Program color white
         * Title = Cyan                 0,255,255
         * successful process = Green   0,255,0
         * Exceptions = Red             255,0,0
         * Input Data = Yellow          255,255,0
         * 
         */

        //editing Date Method dd\mm\yyyy  , Remove Method 
        // edit color for each line in tables
    }
}
