using System;

namespace RepositoryExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "..\\..\\..\\Album.csv";
            try
            {
                var albumRepository = new AlbumRepository(path);
                Menu.MenuBody(albumRepository);
            }
            catch(Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
            


        }
    }
}
