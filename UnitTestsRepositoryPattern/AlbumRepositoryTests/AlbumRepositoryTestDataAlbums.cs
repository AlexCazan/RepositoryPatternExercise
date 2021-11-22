using RepositoryExercise;
using System.Collections;
using System.Collections.Generic;

namespace UnitTestsRepositoryPattern
{
    public class AlbumRepositoryTestDataAlbums
    {
        public static List<Album> GetData()
        {
            var listOfAlbums = new List<Album>
            {
                new Album(1, "Chris Crone", "Turn me on", 2021, "Pop", 20000, true, "ana are mere"),
             new Album(2, "Blaikz", "Bad Habits", 2021, "K-Pop", 25000, true, "fulgi"),
            new Album(3, "Bob Dylan", "Blood on the Tracks", 1975, "Rock", 300000, true, "gogosi"),
            new Album(4, "Prince and the Revolution", "Purple Rain", 1984, "Rap", 10000, false, "sarmale"),
             new Album(5, "The Beatles", "Abbey Road", 1969, "Rock", 234000, false, "ciuperci"),
            };
            return listOfAlbums;
        }
    }
}
