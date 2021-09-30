using System;
using System.Collections.Generic;
using System.Linq;
using Tuna_Session_Builder.Business;
using Tuna_Session_Builder.Domain;

namespace Tuna_Session_Builder
{
    class Program
    {
        static readonly SongService songService = new();
        static Dictionary<int, Song> songList = new();
        static readonly List<Song> sessionList = new();
        static List<Song> suggestionList = new();

        static void Main(string[] args)
        {
            GetAllSongs();

            MainMenu();
        }

        static void MainMenu()
        {
            foreach( var song in sessionList)
                Console.WriteLine(song.Title);

            Console.WriteLine("Choose from the list of suggestions: ");


            if (sessionList.Count == 0)
            {
                FirstSong();
            } else if (sessionList.Count == 6)
            {
                LastSong();
            } else
            {
                NextSong();
            }
        }

        static void FirstSong()
        {
            suggestionList = songService.Search("Starter");
            RemoveRepeats();

            AddMenuIDs();
            foreach(var song in songList)
            {
                Console.WriteLine($"{song.Key}. {song.Value.Title} ({song.Value.Type})");
            }

            var choice = Console.ReadKey();

            sessionList.Add(songList[choice.KeyChar - '0']);

            Console.Clear();
            MainMenu();
        }

        static void LastSong()
        {
            suggestionList = songService.Search("Finisher");
            RemoveRepeats();

            AddMenuIDs();
            foreach (var song in songList)
            {
                Console.WriteLine($"{song.Key}. {song.Value.Title} ({song.Value.Type})");
            }

            var choice = Console.ReadKey();

            sessionList.Add(songList[choice.KeyChar - '0']);

            Console.Clear();

            foreach (var song in sessionList)
                Console.WriteLine($"{song.Title} ({song.Type})");

            return;
        }

        static void NextSong()
        {
            var query = sessionList.Last().Type;
            suggestionList = songService.Suggestion(query);
            RemoveRepeats();

            AddMenuIDs();
            foreach (var song in songList)
            {
                Console.WriteLine($"{song.Key}. {song.Value.Title} ({song.Value.Type})");
            }

            var choice = Console.ReadKey();

            sessionList.Add(songList[choice.KeyChar - '0']);

            Console.Clear();
            MainMenu();
        }

        static void GetAllSongs()
        {
            var songs = songService.Get().ToList(); 
        }

        static void AddMenuIDs()
        {
            songList = new Dictionary<int, Song>();
            for (int i = 0; i < suggestionList.Count; i++)
                songList.Add(i + 1, suggestionList[i]);
        }

        static void RemoveRepeats()
        {
            foreach (var song in suggestionList.ToList())
            {
                if (sessionList.Contains(song))
                {
                    suggestionList.Remove(song);
                }
            }
        }
    }
}
