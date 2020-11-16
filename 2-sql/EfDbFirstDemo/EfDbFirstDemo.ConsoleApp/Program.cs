using EfDbFirstDemo.DataModel;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;
using System;
using System.IO;
using System.Linq;
using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace EfDbFirstDemo.ConsoleApp
{
    class Program
    {

        static DbContextOptions<ChinookContext> s_dbContextOptions;

        static void Main(string[] args)
        {
            using var logStream = new StreamWriter("ef-log.txt");
            var optionsBuilder = new DbContextOptionsBuilder<ChinookContext>();
            //make sure the connectionString either not in the repo or make it into .gitignore file
            optionsBuilder.UseSqlServer(GetConnectionString());
            //for logging
            optionsBuilder.LogTo(x => Debug.WriteLine(x), LogLevel.Error);
            optionsBuilder.LogTo(logStream.WriteLine, LogLevel.Information);

            s_dbContextOptions = optionsBuilder.Options;

            //Display100Tracks();

            Display5Tracks();
            Console.WriteLine();

            EditOneOfThoseTracks();
            Display5Tracks();

            Console.WriteLine();
            InsertANewTrack();
            Display5Tracks();

            Console.WriteLine();
            DeleteThatTrack();
            Display5Tracks();
        }

        public static void EditOneOfThoseTracks()
        {
            // set up connecting
            using var context = new ChinookContext(s_dbContextOptions);
            // get the top track when ordered by name
            var track = context.Tracks.OrderBy(t => t.Name).FirstOrDefault();
            // append to the name
            track.Name = track.Name + " Question";

            //context.Tracks.Update(track); Update method will make the context track the object you pass
            // (if it isn't already)

            // save the changes
            context.SaveChanges();
        }

        public static void InsertANewTrack()
        {
            using var context = new ChinookContext(s_dbContextOptions);
            // figure out what the next track id is
            int nextId = context.Tracks.Count() + 1;

            // create new track
            var newTrack = new Track();
            newTrack.TrackId = nextId;
            newTrack.Name = "\"? Two\"";
            newTrack.AlbumId = 231;
            newTrack.MediaTypeId = 3;
            newTrack.GenreId = 19;
            newTrack.Milliseconds = 500;
            newTrack.Bytes = 1000;
            newTrack.UnitPrice = 10.99m;

            // add the newTrack to the context
            context.Add(newTrack);

            // save the newTrack to the db
            context.SaveChanges();
        }

        public static void DeleteThatTrack()
        {
            // get context
            using var context = new ChinookContext(s_dbContextOptions);
            // find the track that is created in the previous task and remove it
            context.Remove(context.Tracks.Single(t => t.Name == "\"? Two\""));
            // save
            context.SaveChanges();

        }

        static void Display100Tracks()
        {
            using var context = new ChinookContext(s_dbContextOptions);

            var tracks = context.Tracks.Include(t => t.Genre).OrderBy(t => t.Name).Take(100);

            foreach (var track in tracks)
            {
                Console.WriteLine($"{track.TrackId} = {track.Name} ({track.Genre.Name})");
            }
        }

        static void Display5Tracks()
        {
            using var context = new ChinookContext(s_dbContextOptions);

            var tracks = context.Tracks.Include(t => t.Genre).OrderBy(t => t.Name).Take(5);

            foreach (var track in tracks)
            {
                Console.WriteLine($"{track.TrackId} = {track.Name} ({track.Genre.Name})");
            }
        }

        static string GetConnectionString()
        {
            string json;
            try
            {
                json = File.ReadAllText("../../../../../../../ChinookConnection.json");
            }
            catch (IOException)
            {
                Console.WriteLine("Not Correct path");
                throw;
            }
            string connectionString = JsonSerializer.Deserialize<string>(json);
            return connectionString;
        }
    }
}
