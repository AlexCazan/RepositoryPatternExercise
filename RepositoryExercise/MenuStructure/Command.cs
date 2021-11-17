using System;
using System.Linq;
using System.Text;

namespace RepositoryExercise
{
    public class Command
    {
        private IAlbumRepository AlbumRepository { get; set; }
        public Command(IAlbumRepository albumRepository)
        {
            AlbumRepository = albumRepository;
        }
        public void GetAllAlbums()
        {
            var albums = AlbumRepository.GetAlbums();
            Album.Output(albums);

        }
        public void GetAlbumById(int id)
        {
            var album = AlbumRepository.GetAlbumById(id);
            if (album == null)
            {
                Console.WriteLine("Album with that id doesn't exist.");
            }
            else
            {
                Console.WriteLine(album.ToString());
            }
        }
        public void GetAlbumByArtist(string artist)
        {
            var albumsByArtist = AlbumRepository.GetAlbumByArtist(artist);
            if (!albumsByArtist.Any())
            {
                Console.WriteLine("Album with that artist doesn't exist in the current context");
            }
            else
            {
                Album.Output(albumsByArtist);
            }
        }
        public void GetAlbumByTitle(string title)
        {
            var albumsByTitle = AlbumRepository.GetAlbumByTitle(title);
            if (!albumsByTitle.Any())
            {
                Console.WriteLine("Album with that title doesn't exist in the current context");
            }
            else
            {
                Album.Output(albumsByTitle);
            }
        }
        public void InsertAlbum()
        {
            StringBuilder sb = new();
            sb.Append("0,");
            Console.WriteLine("Write the Artist: ");
            string newArtist = Console.ReadLine();
            sb.Append(newArtist).Append(',');
            Console.WriteLine("Write the Title: ");
            string newTitle = Console.ReadLine();
            sb.Append(newTitle).Append(',');
            Console.WriteLine("Write the Year: ");
            string newYear = Console.ReadLine();
            sb.Append(newYear).Append(',');
            Console.WriteLine("Write the Genre: ");
            string newGenre = Console.ReadLine();
            sb.Append(newGenre).Append(',');
            Console.WriteLine("Write the Sales: ");
            string newSales = Console.ReadLine();
            sb.Append(newSales).Append(',');
            Console.WriteLine("Write the validity of ownership(true or false): ");
            string newOwn = Console.ReadLine();
            sb.Append(newOwn).Append(',');
            Console.WriteLine("Write the RecordLabel: ");
            string newRecordLabel = Console.ReadLine();
            sb.Append(newRecordLabel).Append(',');

            AlbumRepository.InsertAlbum(Album.Parse(sb.ToString()));
        }
        public void UpdateAlbum()
        {
            Console.WriteLine("\r\nPlease type the id of the album you want to update.");
            var id = Int32.Parse(Console.ReadLine());
            Console.WriteLine("\r\nType one property from these: artist,title,year,genre,sales,owned and recordLabel");
            var property = Console.ReadLine();
            Console.WriteLine("\r\nType the new value for the selected property");
            var value = Console.ReadLine();
            Console.WriteLine(AlbumRepository.UpdateAlbum(id,property,value));
        }
    }
}
