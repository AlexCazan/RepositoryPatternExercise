using System;
using System.IO;
using System.Text;
using static RepositoryExercise.Validation;

namespace RepositoryExercise
{
    public static class MenuFunctions
    {
        public static Tuple<string, string> ChoosingFile(string extension, string pathFolder)
        {
            DisplayFiles(extension);
            extension = extension.Remove(0, 1);
            Console.WriteLine("Type the name of the file you want to make some changes.");
            var fileName = Console.ReadLine();
            var sb = new StringBuilder(fileName);
            if (!fileName.EndsWith(extension))
            {
                sb.Append(extension);
            }
            var filePath = sb.Insert(0, pathFolder).ToString();
            if (extension == ".csv")
            {
                CheckIfFileExistsCSV(filePath);
            }
            else
            {
                CheckIfFileExistsXML(filePath);
            }
            return Tuple.Create(filePath, fileName);
        }
        public static void Options()
        {
            Console.WriteLine("\r\nChoose an option:");
            Console.WriteLine("1) Get all albums");
            Console.WriteLine("2) Get album by id");
            Console.WriteLine("3) Get albums by artist");
            Console.WriteLine("4) Get albums by title");
            Console.WriteLine("5) Insert new album");
            Console.WriteLine("6) Delete album by id");
            Console.WriteLine("7) Update an album");
            Console.WriteLine("8) Save");
            Console.WriteLine("9) Back to the first menu");
            Console.WriteLine("10) Exit the application");
        }
        public static void DisplayFiles(string extension)
        {
            Console.WriteLine("These are the files available for change.");
            var files = Directory.GetFiles($"..\\..\\..\\{extension.Remove(0, 2).ToUpper()} FilesForUse", extension);
            foreach (var item in files)
            {
                Console.WriteLine(Path.GetFileName(item));
            }
        }


        public static void OptionsFiles()
        {
            Console.WriteLine("Welcome.");
            Console.WriteLine("Select the extension for the files you want to work with.");
            Console.WriteLine("1) csv");
            Console.WriteLine("2) xml");
            Console.WriteLine("3) Exit.");
        }

        public static void FileOperations(Command command, IAlbumRepository albumRepository, string pathSave, string fileName)
        {
            var finishForSecondMenu = false;
            while (finishForSecondMenu != true)
            {
                Options();
                Console.Write("\r\nSelect an option: ");
                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        command.GetAllAlbums();
                        break;
                    case "2":
                        var id = ValidateStringOnlyDigits("Write the id: ");
                        command.GetAlbumById(id);
                        break;
                    case "3":
                        Console.WriteLine("Write the artist: ");
                        var artist = Console.ReadLine();
                        command.GetAlbumByArtist(artist);
                        break;
                    case "4":
                        Console.WriteLine("Write the title: ");
                        var title = Console.ReadLine();
                        command.GetAlbumByTitle(title);
                        break;
                    case "5":
                        command.InsertAlbum();
                        Console.WriteLine("Album added successfully");
                        break;
                    case "6":
                        command.GetAllAlbums();
                        var idAlbumToDelete = ValidateStringOnlyDigits("Type the id of the album you want to delete from the above: ");
                        Console.WriteLine(albumRepository.DeleteAlbum(idAlbumToDelete));
                        break;
                    case "7":
                        command.GetAllAlbums();
                        command.UpdateAlbum();
                        break;
                    case "8":
                        albumRepository.Save(pathSave, fileName);
                        Console.WriteLine("Changes saved successfully");
                        break;
                    case "9":
                        Console.WriteLine("Returning to the first menu...");
                        finishForSecondMenu = true;
                        break;
                    case "10":
                        Console.WriteLine("Exiting...");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("The option is invalid.");
                        break;
                }
            }
        }
    }
}
