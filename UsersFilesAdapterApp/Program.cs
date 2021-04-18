using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersMettlerToledoApp.Adapters;

namespace UsersMettlerToledoApp
{
    class Program
    {
        static string folderPath = @"..\..\..\Users\";
        static string jsonFileName = "Users.json";
        static string xmlFileName = "Users.xml";
        static string csvFileName = "Users.csv";

        public static void PrintUsers(FormatAdapter fileAdapter)
        {
            fileAdapter.ReadFromFile();
            Console.WriteLine(fileAdapter.GetUsersInfo());
        }

        public static void ChangeFilePaths()
        {
            Console.WriteLine("podaj ścieżke folderu");
            folderPath = Console.ReadLine();

            Console.WriteLine("podaj nazwę pliku json");
            jsonFileName = Console.ReadLine();

            Console.WriteLine("podaj nazwę pliku xml");
            xmlFileName = Console.ReadLine();

            Console.WriteLine("podaj nazwę pliku csv");
            csvFileName = Console.ReadLine();

        }



        static void Main(string[] args)
        {
            // string folderPath = @"..\..\..\..\Users\Users.json";   

            Console.WriteLine("Jeśli chcesz podać inną ścieżke folderu i plików wpisz 1, jeśli nie wpisz dowolny inny klawisz:");
            if(Console.ReadLine()=="1")
            {
                ChangeFilePaths();
            }

            try
            {
                List<FormatAdapter> fileAdapters = new List<FormatAdapter>
            {
                new JsonAdapter(folderPath + jsonFileName),
                new XmlAdapter(folderPath + xmlFileName),
                new CsvAdapter(folderPath + csvFileName)
            };

                foreach (var fileAdapter in fileAdapters)
                {
                    PrintUsers(fileAdapter);
                }
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            
            
            Console.ReadLine();

        }
    }
}
