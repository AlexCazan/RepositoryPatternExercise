using RepositoryExercise.Repositories;
using System.IO;

namespace RepositoryExercise
{
    public class AlbumRepositoryCSV : AlbumRepository
    {
        public AlbumRepositoryCSV(string path)
        {
                using (var reader = new StreamReader(path))
                {
                    var headerLine = reader.ReadLine();
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        
                        albums.Add(Album.Parse(line));

                    }
                }
        }

        public override void Save(string path)
        {
            using (var writer = new StreamWriter(path))
            {
                writer.WriteLine("Id,Artist,Title,Year,Genre,Sales,Owned,Record Label");
                foreach (var album in albums)
                {
                    writer.WriteLine(album.ToString());
                }
            }
        }
    }
}
