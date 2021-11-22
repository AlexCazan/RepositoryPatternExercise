using RepositoryExercise.Repositories;
using System;
using static RepositoryExercise.MenuFunctions;
namespace RepositoryExercise
{
    public class Menu
    {
        public static void MenuBody()
        {
            var pathForCSVFiles = "..\\..\\..\\CSV FilesForUse\\";
            var pathForXMLFiles = "..\\..\\..\\XML FilesForUse\\";
            var pathSaveCSV = "..\\..\\..\\CSV FileSave\\";
            var pathSaveXML = "..\\..\\..\\XML FileSave\\";
            bool finishForFirstMenu = false;

            while (finishForFirstMenu != true)
            {
                Console.Clear();
                OptionsFiles();
                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        var fileInformation = ChoosingFile("*.csv",pathForCSVFiles);
                        var albumRepositoryCSV = new AlbumRepositoryCSV(fileInformation.Item1);
                        var command = new Command(albumRepositoryCSV);
                        FileOperations(command, albumRepositoryCSV, pathSaveCSV,fileInformation.Item2);
                        break;
                    case "2":
                        fileInformation = ChoosingFile("*.xml", pathForXMLFiles);
                        var albumRepositoryXML = new AlbumRepositoryXML(fileInformation.Item1);
                        command = new Command(albumRepositoryXML);
                        FileOperations(command, albumRepositoryXML, pathSaveXML, fileInformation.Item2);
                        break;
                    case "3":
                        Console.WriteLine("Exiting...");
                        finishForFirstMenu = true;
                        break;
                    default:
                        Console.WriteLine("The option is invalid.");
                        break;
                }
            }
        }

        
    }
}
