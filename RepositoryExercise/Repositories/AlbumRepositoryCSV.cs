using RepositoryExercise.Repositories;
using System;
using System.IO;
using System.Text;

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

        public override void Save(string path,string fileName)
        {
            string fileNameSave = String.Format("{0}__{1}", fileName + "_UpdatedAt", DateTime.Now.ToString("yyyyMMddhhmmss"));
            var sb = new StringBuilder(path);
            sb.Append(fileNameSave).Append(".csv");
            using (var writer = new StreamWriter(sb.ToString()))
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
