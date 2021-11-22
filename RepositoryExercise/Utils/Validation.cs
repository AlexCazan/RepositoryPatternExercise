using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace RepositoryExercise.Utils
{
    public static class Validation
    {
        public static void CheckIfFileExistsCSV(string filePath)
        {
            if (!File.Exists(filePath))
            {
                using (StreamWriter streamWriter = new(filePath))
                {
                    streamWriter.WriteLine("Id,Artist,Title,Year,Genre,Sales,Owned,Record Label");
                }
            }
        }
        public static void CheckIfFileExistsXML(string filePath)
        {
            if (!File.Exists(filePath))
            {
                new XDocument(new XElement("Albums")).Save(filePath);
            }
        }
        public static int ValidateStringOnlyDigits(string message)
        {
            var isCorrect = false;
            var id = "";
            while (!isCorrect)
            {
                Console.WriteLine(message);
                id = Console.ReadLine();
                if (!id.All(char.IsDigit))
                {
                    Console.WriteLine("Please insert only digits.");
                }
                else
                {
                    isCorrect = true;
                }
            }
            return Int32.Parse(id);

        }
    }
}
