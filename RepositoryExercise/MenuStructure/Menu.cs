using RepositoryExercise.Repositories;
using System;

namespace RepositoryExercise
{
    public class Menu
    {
        public static void MenuBody()
        {
            var pathCSV = "..\\..\\..\\CSV Files\\Album.csv";
            var pathXML = "..\\..\\..\\XML Files\\Album.xml";
            bool finishForFirstMenu = false;

            while (finishForFirstMenu != true)
            {
                Console.Clear();
                OptionsFiles();
                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        var pathSaveCSV = "..\\..\\..\\CSV Files\\AlbumsSave.csv";
                        var albumRepositoryCSV = new AlbumRepositoryCSV(pathCSV);
                        var command = new Command(albumRepositoryCSV);
                        FileOperations(command, albumRepositoryCSV, pathSaveCSV);
                        break;
                    case "2":
                        var pathSaveXML = "..\\..\\..\\XML Files\\AlbumsSave.xml";
                        var albumRepositoryXML = new AlbumRepositoryXML(pathXML);
                        command = new Command(albumRepositoryXML);
                        FileOperations(command, albumRepositoryXML, pathSaveXML);
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

        public static void OptionsFiles()
        {
            Console.WriteLine("Welcome to the studio!");
            Console.WriteLine("Which file do you want to make some changes?");
            Console.WriteLine("1) CSV file");
            Console.WriteLine("2) XML file");
            Console.WriteLine("3) Exit.");
        }

        public static void FileOperations(Command command, IAlbumRepository albumRepository,string pathSave)
        {
            bool finishForSecondMenu = false;
            while (finishForSecondMenu != true)
            {
                Options();
                Console.Write("\r\nSelect an option: ");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        command.GetAllAlbums();
                        break;
                    case "2":
                        Console.WriteLine("Write the id: ");
                        int id = Int32.Parse(Console.ReadLine());
                        command.GetAlbumById(id);
                        break;
                    case "3":
                        Console.WriteLine("Write the artist: ");
                        string artist = Console.ReadLine();
                        command.GetAlbumByArtist(artist);
                        break;
                    case "4":
                        Console.WriteLine("Write the title: ");
                        string title = Console.ReadLine();
                        command.GetAlbumByTitle(title);
                        break;
                    case "5":
                        command.InsertAlbum();
                        Console.WriteLine("Album added successfully");
                        break;
                    case "6":
                        command.GetAllAlbums();
                        Console.WriteLine("Type the id of the album you want to delete from the above: ");
                        int idAlbumToDelete = Int32.Parse(Console.ReadLine());
                        Console.WriteLine(albumRepository.DeleteAlbum(idAlbumToDelete));
                        break;
                    case "7":
                        command.GetAllAlbums();
                        command.UpdateAlbum();
                        break;
                    case "8":
                        albumRepository.Save(pathSave);
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
