using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Configuration;
using System.Configuration.Assemblies;
using System.Diagnostics;

namespace SrssOS
{
    class Program
    {
        
        private static void golf()
        {

        }
        private static void licence()
        {

        }
        private static void loan()
        {
            Console.Clear();
            Console.Title = "Load Application 9000! - Srss Operating System";
            Console.WriteLine("How Much Money Do You Make?");
            double salary = Convert.ToDouble(Console.ReadLine());
            if (salary >= 30000)
            {
                Console.WriteLine("How long have you been at your job?");
                double yearsOnJob = Convert.ToDouble(Console.ReadLine());
                if (yearsOnJob >= 2)
                {
                    Console.WriteLine("Congrats! You qualify for a loan.");
                } 
                else
                {
                    Console.WriteLine("You haven't worked long enough");
                }
            }
            else
            {
                Console.WriteLine("Get A Better Job, You do not qualify right now.");
            }
            Console.ReadKey();
        }
        private static void getComputerInfo()
        {

            Console.WriteLine("Getting Computer Information...");
            Thread.Sleep(2000);
            Console.WriteLine("Your Computer name is: " + Environment.MachineName);
            Thread.Sleep(2000);

            Console.WriteLine("Your Computer's Operating System is: " + Environment.OSVersion);
            Thread.Sleep(2000);
            Console.WriteLine("Your User name is:  " + Environment.UserDomainName + "/" + Environment.UserName);
            Thread.Sleep(2000);
            Console.WriteLine("Your Computer's Version is: " + Environment.Version);
            Thread.Sleep(1000);
            Console.WriteLine();
            Console.WriteLine("Getting Network Information...");
            Thread.Sleep(3000);


            String strHostName = System.Net.Dns.GetHostName();

            foreach (System.Net.IPAddress ipaddress in System.Net.Dns.GetHostEntry(strHostName).AddressList)
            {
                Console.WriteLine("Your IP Address is: " + ipaddress.ToString());
            }
        }
        //gets the setting from the config
        private static string getSetting(String key)
        {
            return ConfigurationManager.AppSettings[key];
        }
        //sets the new setting in the config
        private static void SetSetting(string key, string value)
        {
            Configuration config =
                ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings[key].Value = value;
            config.Save(ConfigurationSaveMode.Full, true);
            ConfigurationManager.RefreshSection("appSettings");
        }

        //deletes the setting if you want to reset the program to "Factory Settings"
        private static void delSetting(string key)
        {
            Configuration config =
    ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings[key].Value = "null";
            config.Save(ConfigurationSaveMode.Full, true);
            ConfigurationManager.RefreshSection("appSettings");
        }
        //runs the login function
        private static void Login()
        {
            if (getSetting("password").Equals("null"))
            {
                Console.WriteLine("Please type a Password...");
                Console.Title = "Please Enter a Password";
                string password = Console.ReadLine();
                SetSetting("password", password);
                Console.WriteLine("Password is now Set to " + password);
                Thread.Sleep(2000);
                Console.Clear();

            }
            else
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                Console.Title = "Please Your Password";
                Console.WriteLine("Password Found.");
                Console.WriteLine("Please Enter Your Password");
                Boolean typepass = true;
                while (typepass == true)
                {
                    if (getSetting("password").Equals(Console.ReadLine()))
                    {
                        Console.WriteLine("Password Correct!");
                        Console.WriteLine("Logging You in...");
                        typepass = false;
                        Thread.Sleep(2000);
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("Incorrect Password");
                        Console.WriteLine("Please Enter the Correct Password");
                    }
                }

            }
        }

        //runs the mad libs program or function apart of the assignment do "madlibs" to run
        private static void madLibs()
        {
            String name;
            String verb1;
            String noun1;
            String pronoun1;
            String noun2;
            String pronoun2;
            String verb2;
            Console.WriteLine("Please Enter a Name...");
            name = Console.ReadLine();
            Console.WriteLine("Plase Enter a Verb...");
            verb1 = Console.ReadLine();
            Console.WriteLine("Plase Enter a Noun...");
            noun1 = Console.ReadLine();
            Console.WriteLine("Plase Enter a Pronoun...");
            pronoun1 = Console.ReadLine();
            Console.WriteLine("Plase Enter a Noun...");
            noun2 = Console.ReadLine();
            Console.WriteLine("Plase Enter a Pronoun...");
            pronoun2 = Console.ReadLine();
            Console.WriteLine("Plase Enter a Verb...");
            verb2 = Console.ReadLine();
            Console.WriteLine("One day " + name + " was " + verb1 + " to the " + noun1 + ". On the way, " + pronoun1 + " saw a " + noun2 + " This was a /n surprise so " + pronoun2 + " " + verb2 + " quickly.");
            Console.WriteLine("Press Any key to return to the Main Menu...");
            Console.ReadKey();
        }
        //runs the tax calculator do "tax" to run
        private static void taxCalculator()
        {
            //prints the title
            Console.SetCursorPosition((Console.WindowWidth - 18) / 2, Console.CursorTop);
            Console.WriteLine("==================");
            Console.SetCursorPosition((Console.WindowWidth - 18) / 2, Console.CursorTop);
            Console.WriteLine("  Sobeys Cashier");
            Console.SetCursorPosition((Console.WindowWidth - 18) / 2, Console.CursorTop);

            Console.WriteLine("==================");









            //Background and Foreground Color
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            //Q1
            //GST and PST
            double GSTrate = 0.05, PSTrate = 0.08;
            //double stickerPrice; //declare variable stickerPrice
            double GSTPaid;
            double PSTPaid;
            double totalCost = 0;
            // double ammountPaid;
            //double changeReceived;
            // int timesFlashed = 0;
            double totalBeforeTax = 0;
            List<double> prices = new List<Double>();


            Console.WriteLine("Enter a Price");

            Boolean pricing = true;
            String typed;
            while (pricing == true)
            {
                typed = Console.ReadLine();
                if (typed.Equals("pay"))
                {
                    pricing = false;
                }
                else {
                    prices.Add(Convert.ToDouble(typed));
                    Console.WriteLine("When Finished Type pay");
                }
            }
            //counts the number of prices and runs in loop for each number
            foreach (double price in prices)
            {
                Console.WriteLine(" - " + Math.Round(price, 2));
                totalBeforeTax = totalBeforeTax + price;
            }
            GSTPaid = totalBeforeTax * GSTrate;
            PSTPaid = totalBeforeTax * PSTrate;
            //prints the data
            Console.WriteLine("Before Tax = " + Math.Round(totalBeforeTax, 2));
            Console.WriteLine("GST = " + Math.Round(GSTPaid, 2));
            Console.WriteLine("PST = " + Math.Round(PSTPaid, 2));
            totalCost = PSTPaid + GSTPaid + totalBeforeTax;
            Console.WriteLine("Total = " + Math.Round(totalCost, 2));

            Console.WriteLine("Press Any Key to Return to the Main Menu");
            Console.ReadKey();


        }
        //do "squares" to run
        private static void Squares()
        {
            Console.WriteLine("Please Type a Number");
            double typed;
            typed = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Your Number Squarerooted is : " + Math.Sqrt(typed));
            Console.WriteLine("Press Any Key to return to the Main Menu...");
            Console.ReadKey();
        }
        //do "circles" to run
        private static void Circles()
        {
            Boolean Program = true;
            while (Program == true)
            {
                Console.Clear();
                Console.WriteLine("Please Type A Number");
                string typed = Console.ReadLine();

                double rad = Convert.ToDouble(typed);
                double dim;
                double circ;
                double area;
                dim = rad + rad;
                circ = dim * Math.PI;
                area = rad * rad * Math.PI;
                Console.WriteLine("Radius = " + Math.Round(rad));
                Console.WriteLine("Diameter = " + Math.Round(dim));
                Console.WriteLine("Circumference = " + Math.Round(circ));
                Console.WriteLine("Area = " + Math.Round(area));
                Console.WriteLine();
                Console.WriteLine("Would you like to Return to the Main Menu? (yes or no)");
                typed = Console.ReadLine();
                if (typed.Equals("yes"))
                {
                    Console.WriteLine("Shutting Down Circles...");
                    Thread.Sleep(1500);
                    Program = false;
                }
                else
                {
                    Console.WriteLine("Restarting Circles...");
                    Thread.Sleep(1000);
                }
            }
        }
        static void SearchGoogle(string t)
        {
            Process.Start("http://google.com/search?q=" + t);
        }
        static void SearchDictionary(String search)
        {
            Process.Start("https://www.vocabulary.com/dictionary/" + search);
        }
        static void Main(string[] args)
        {

            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.Clear();
            Login();
            Console.Title = "Main Menu - Srss Operating System";
            Boolean mainProgram = true;
            while (mainProgram == true)
            {
                Console.Title = "Main Menu - Srss Operating System";
                String text = Console.ReadLine();
                if (text.Equals("info"))
                {
                    Console.Clear();
                    Console.Title = "Computer Info - Srss Operating System";
                    getComputerInfo();
                }
                else if (text.Equals("shutdown"))
                {
                    Console.WriteLine("Program Shutting Down...");
                    Thread.Sleep(3000);
                    mainProgram = false;
                }
                else if (text.Equals("squares"))
                {
                    Console.Clear();
                    Console.Title = "Squares Calculator - Srss Operating System";
                    Squares();
                    Console.Clear();
                    //run function
                }
                else if (text.Equals("madlibs"))
                {
                    Console.Clear();
                    Console.Title = "Mad Libs - Srss Operating System";
                    madLibs();
                    Console.Clear();
                    //Run the private static void
                }
                else if (text.Equals("tax"))
                {
                    Console.Clear();
                    Console.Title = "Tax Calculator - Srss Operating System";
                    taxCalculator();
                    //Run the function
                    Console.Clear();
                }
                else if (text.Equals("help"))
                {
                    Console.Clear();
                    Console.WriteLine("============");
                    Console.WriteLine("==Commands==");
                    Console.WriteLine("============");
                    Console.WriteLine();
                    Console.WriteLine(" - squares");
                    Console.WriteLine(" - madlibs");
                    Console.WriteLine(" - tax");
                    Console.WriteLine(" - circles");
                    Console.WriteLine(" - help");
                    Console.WriteLine(" - reset");
                    Console.WriteLine(" - changepassword");
                    Console.WriteLine(" - info");
                    Console.WriteLine(" - notepad");
                    Console.WriteLine(" - photo");
                    Console.WriteLine(" - google");

                }
                else if (text.Equals("loan"))
                {
                    loan();
                    Console.Clear();
                }
                else if (text.Equals("circles"))
                {
                    Console.Clear();
                    Console.Title = "Circles Calculator - Srss Operating System";
                    Circles();
                    Console.Clear();
                }
                else if (text.Equals("google"))
                {
                    Console.WriteLine("What Do you Want to Search for?");
                    string search = Console.ReadLine();
                    SearchGoogle(search);
                }
                else if (text.Equals("dict"))
                {
                    Console.WriteLine("Please Enter Your Search Key");
                    SearchDictionary(Console.ReadLine());
                }
                else if (text.Equals("changepassword"))
                {
                    Console.Title = "Change Password - Srss Operating System";
                    Console.WriteLine("Please Type Your New Password");
                    string typed = Console.ReadLine();
                    SetSetting("password", typed);
                    Console.WriteLine("Password set to " + typed + " !");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
                else if (text.Equals("notepad"))
                {
                    System.Diagnostics.Process.Start("notepad");
                }
                else if (text.Equals("photo")) {
                    Process.Start("C://Program Files/Adobe/Adobe Photoshop CC 2015.5/Photoshop.exe");
                }
                else if (text.Equals("reset"))
                {
                    Console.WriteLine("Are you sure? (yes or no)");
                    string answer = Console.ReadLine();
                    if (answer.Equals("yes"))
                    {
                        Console.WriteLine("resetting and shuting down...");
                        Thread.Sleep(2000);
                        delSetting("password");
                        var proc = new Process();
                        proc.StartInfo.FileName = "SrssOS.exe";
                        proc.Start();
                        String thing = AppDomain.CurrentDomain.BaseDirectory;
                        System.Diagnostics.Process.Start(thing, "SrssOS");
                        mainProgram = false;

                    }
                    else
                    {
                        Console.WriteLine("Canceling Reset...");
                        Thread.Sleep(2000);
                    }
                }
                else
                {
                    Console.WriteLine("Unknown Command!");
                    Console.WriteLine("Please do command 'help' to see a list of Commands");
                }

                {
                }
            }




        }
    }
}
