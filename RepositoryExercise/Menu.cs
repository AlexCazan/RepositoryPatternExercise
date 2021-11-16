using System;

namespace RepositoryExercise
{
    public class Menu
    {
        public static void MenuBody(IAlbumRepository albumRepository)
        {
            Console.Clear();
            Options();
            bool finish = false;
            var command = new Command(albumRepository);
            var pathSave = "..\\..\\..\\AlbumsSave.csv";

            while (finish!=true)
            {
                Console.Write("\r\nSelect an option: ");
                string s = Console.ReadLine();

                switch (s)
                {
                    case "1":
                        command.GetAllAlbums();
                        Options();
                        break;
                    case "2":
                        Console.WriteLine("Write the id: ");
                        int id = Int32.Parse(Console.ReadLine());
                        command.GetAlbumById(id);
                        Options();
                        break;
                    case "3":
                        Console.WriteLine("Write the artist: ");
                        string artist = Console.ReadLine();
                        command.GetAlbumByArtist(artist);
                        Options();
                        break;
                    case "4":
                        Console.WriteLine("Write the title: ");
                        string title = Console.ReadLine();
                        command.GetAlbumByTitle(title);
                        Options();
                        break;
                    case "5":
                        command.InsertAlbum();
                        Console.WriteLine("Album added successfully");
                        Options();
                        break;
                    case "6":
                        Console.WriteLine("Write the id: ");
                        int idAlbumToDelete = Int32.Parse(Console.ReadLine());
                        Console.WriteLine(albumRepository.DeleteAlbum(idAlbumToDelete));
                        Options();
                        break;
                    case "7":
                        Console.WriteLine("Write the id, property and value for update");
                        var paramss = Console.ReadLine().Split(",");
                        Console.WriteLine(albumRepository.UpdateAlbum(Int32.Parse(paramss[0]), paramss[1], paramss[2]));
                        Options();
                        break;
                    case "8":
                        albumRepository.Save(pathSave);
                        Console.WriteLine("Changes saved successfully");
                        Console.WriteLine("Exiting...");
                        finish = true;
                        break;
                    default:
                        Console.WriteLine("The option is invalid.");
                        Options();
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
            Console.WriteLine("7) Update an album by title or artist");
            Console.WriteLine("8) Exit");

        }
    }
}
