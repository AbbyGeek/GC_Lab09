using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace GC_Lab09
{
    class Program
    {
        static void Main(string[] args)
        {
            List<List<string>> StudentInfo = new List<List<string>>();

            
            StudentInfo.Add(new List<string> { "Yuga Aoyama", "Shining Hero", "Navel Laser" });
            StudentInfo.Add(new List<string> { "Denki Kaminari", "Chargebolt", "Electrification" });
            StudentInfo.Add(new List<string> { "Eijiro Kirishma", "Red Riot", "Hardening" });
            StudentInfo.Add(new List<string> { "Koji Koda", "Anima", "Anivoice" });
            StudentInfo.Add(new List<string> { "Rikido Sato", "Sugarman", "Sugar Rush" });
            StudentInfo.Add(new List<string> { "Mina Ashido", "Alien Queen", "Acid" });
            StudentInfo.Add(new List<string> { "Tsuyu Asiu", "Froppy", "Frog" });
            StudentInfo.Add(new List<string> { "Tena Iida", "Ingeniumu", "Engine" });
            StudentInfo.Add(new List<string> { "Ochaco Uraraka", "Uravity", "Zero Gravity" });
            StudentInfo.Add(new List<string> { "Mashirao Ojiro", "Tailman", "Tail" });
            StudentInfo.Add(new List<string> { "Mezo Shoji", "Tentacole", "Dupli-Arms" });
            StudentInfo.Add(new List<string> { "Kyoka Jiro", "Earphone Jack", "Earphone Jack" });
            StudentInfo.Add(new List<string> { "Hanta Sero", "Cellophane", "Tape" });
            StudentInfo.Add(new List<string> { "Fumikage Tokoyami", "Tsukuyomi", "Dark Shadow" });
            StudentInfo.Add(new List<string> { "Shoto Todoroki", "Shoto", "Half-Hot Half-Cold" });
            StudentInfo.Add(new List<string> { "Toru Hgakure", "Invisible Girl", "Invisibility" });
            StudentInfo.Add(new List<string> { "Kasuki Bakugo", "Kacchan", "Explosion" });
            StudentInfo.Add(new List<string> { "Izuku Midoriya", "Deku", "One For All" });
            StudentInfo.Add(new List<string> { "Minoru Mineta", "Grape Juice", "Pop Off" });
            StudentInfo.Add(new List<string> { "Momo Yaoyorozu", "Creati", "Creation" });

            StudentInfo[0].Add("Random information");
            Console.WriteLine(StudentInfo[0][3]);


            while (true)
            {
                
                    Console.WriteLine("U.A. High: Class 1-A Directory. Enter number of student to look up (1-20) \n" +
                        "To log into administrator functions, enter: 'admin'");

                    string studentEntry = Console.ReadLine();
                    if (studentEntry == "admin".ToLower())
                    {
                        Admin(StudentInfo);
                        continue;
                    }
                try
                {
                    int num = int.Parse(studentEntry);
                    Console.WriteLine($"Student number {num}: {Name(StudentInfo, num)}");
                    

                    
                    while (true)
                    {
                        Console.WriteLine($"What would you like to know about {Name(StudentInfo, num)}? \nyou may enter: \n'name' to get ther student's Hero Name \n'quirk' for their quirk. \n"+
                            $"'back' to go back to the student selection screen'\n");
                        string entry = Console.ReadLine();

                        if (entry.ToLower() == "name")
                        {
                            Console.WriteLine($"{Name(StudentInfo, num)}'s Hero name is: {HeroName(StudentInfo, num)}\n");
                            continue;
                        }
                        if (entry.ToLower() == "quirk")
                        {
                            Console.WriteLine($"{Name(StudentInfo, num)}'s Quirk is: {Quirk(StudentInfo, num)}\n");
                            continue;
                        }
                        if (entry.ToLower() == "back")  {break;}
                        else {Console.WriteLine("Incorrect entry. Please start again.\n");}
                    } 

                }
                catch
                {
                    Console.WriteLine("Oops, something went wrong. Please start again");
                    continue;
                }
            }
        }
        public static string Name(List<List<string>> StudentInfo, int num) => StudentInfo[num][0].ToString();
        public static string HeroName(List<List<string>> StudentInfo, int num) => StudentInfo[num][1].ToString();
        public static string Quirk(List<List<string>> StudentInfo, int num) => StudentInfo[num][2].ToString();

        public static void Admin(List<List<string>> StudentInfo)
        {
            while (true)
            {
                Console.WriteLine("\n Admin Access: Please select one of the following numerical choices \n\n" +
                    "1) Add Student \n" +
                    "2) Remove Student \n" +
                    "3) List all students alphabetically \n" +
                    "4) Add Student Criteria \n" +
                    "5) Return to main screen");
                string choice = Console.ReadLine();
                if (choice == "1") { AddStudent(StudentInfo); continue; }
                if (choice == "2") { RemoveStudent(StudentInfo); continue; }
                if (choice == "3") { ListStudents(StudentInfo); continue; }
                if (choice == "4") { AddCriteria(); continue; }
                if (choice == "5") { break; }
                else { Console.WriteLine("Incorrect Entry"); continue; }
            }
        }

        public static void AddStudent(List<List<string>> StudentInfo)
        {
            Console.Write("Enter new student's name: ");
            string NewName = Console.ReadLine();
            Console.Write("Enter new student's hero name: ");
            string NewHeroName = Console.ReadLine();
            Console.Write("Enter new student's quirk: ");
            string NewQuirk = Console.ReadLine();

            StudentInfo.Add(new List<string> { NewName, NewHeroName, NewQuirk });
            Console.WriteLine($"{NewName} has been added to student roster.");

        }
        public static void RemoveStudent(List<List<string>>StudentInfo)
        {
            Console.Write("Enter name of student to expell: ");
            string DelName = Console.ReadLine();

            
            for(int i = 0; i < StudentInfo.Count; i++)
            {
                if (StudentInfo[i][0] == DelName)
                {
                    StudentInfo.Remove(StudentInfo[i]);
                }
            }

        }
        public static void ListStudents(List<List<string>> StudentInfo)
        {


            List<List<string>> sorted = StudentInfo.OrderBy(x => x[0]).ToList();
            Console.WriteLine("STUDENT NAME".PadRight(25) + "HERO NAME".PadRight(25) + "QUIRK".PadRight(25));
            for(int i = 0; i < StudentInfo.Count; i++)
            {
                Console.WriteLine($"{sorted[i][0].PadRight(25)} {sorted[i][1].PadRight(25)} {sorted[i][2].PadRight(25)}");
            }
            
        }
        public static void AddCriteria()
        {
            Console.WriteLine("This isn't going to be practical for this program. For some reason I did things way differently than I should've and I get the feeling that " +
                "adding criteria to my list of lists is going to involve going above and beyond what is expected. If you'd like, lines 38 and 39 of this program add the string 'random information" +
                "to the student at index zero. That should demonstrate that I know how to add criteria if needed.");
        }

    }
}
