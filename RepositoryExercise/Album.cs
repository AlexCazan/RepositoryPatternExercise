using System;
using System.Collections.Generic;

namespace RepositoryExercise
{
    public class Album
    {
        public int Id { get; set; }
        public string Artist { get; set; }
        public string Title { get; set; }
        
        public int Year { get; set; }

        public string Genre { get; set; }

        public int Sales { get; set; }
        public bool Owned { get; set; }
        public string RecordLabel { get; set; }

        public Album(int id, string artist, string title, int year, string genre, int sales, bool owned, string recordLabel)
        {
            Id = id;
            Artist = artist;
            Title = title;
            Year = year;
            Genre = genre;
            Sales = sales;
            Owned = owned;
            RecordLabel = recordLabel;
        }

        public override string ToString()
        {
            return $"{Id},{Artist},{Title},{Year},{Genre},{Sales},{Owned},{RecordLabel}";
        }
        public static Album Parse(string album)
        {
            var splitPropertiesAlbum = album.Split(",");
            int id = Int32.Parse(splitPropertiesAlbum[0]);
            string artist = splitPropertiesAlbum[1];
            string title = splitPropertiesAlbum[2];
            int year = Int32.Parse(splitPropertiesAlbum[3]);
            string genre = splitPropertiesAlbum[4];
            int sales = Int32.Parse(splitPropertiesAlbum[5]);
            bool owned = bool.Parse(splitPropertiesAlbum[6]);
            string recordLabel = splitPropertiesAlbum[7];
            return new Album(id, artist, title, year, genre, sales, owned, recordLabel);
        }
        public static void Output(IEnumerable<Album> albums)
        {
            foreach (var item in albums)
            {
                Console.WriteLine(item.ToString());
            };
        }
    }
}
