using System;
using System.Collections.Generic;
using System.Linq;
using Tuna_Session_Builder.Business;
using Tuna_Session_Builder.Domain;
using Tuna_Session_Builder.Domain.Objects;

namespace Tuna_Session_Builder
{
    class Program
    {
        static readonly SongService songService = new(new Mockdata());
        static Dictionary<int, Song> songList = new();
        static readonly List<Song> sessionList = new();
        static List<Song> suggestionList = new();
        static List<Song> songs = songService.Get().ToList();
        static void Main(string[] args)
        {
            MainMenu();
        }

        static void MainMenu()
        {
            Console.WriteLine("SessionList: ");
            foreach( var song in sessionList)
                Console.WriteLine($"- {song.Title}");

            if (sessionList.Count == 0)
            {
                FirstSong();
            } else if (sessionList.Count >= 5)
            {
                LastSong();
            } else
            {
                NextSong();
            }
        }

        static void FirstSong()
        {
            Console.WriteLine("Choose from the list of suggestions: ");
            suggestionList = songService.Search(songs, "Starter");
            RemoveRepeats();

            AddMenuIDs();
            foreach(var song in songList)
            {
                Console.WriteLine($"{song.Key}. {song.Value.Title} ({song.Value.Type})");
            }
            Console.WriteLine($"{songList.Count + 1}. Search");

            var choice = Console.ReadKey().KeyChar - '0';

            if (choice > 0 && choice <= suggestionList.Count)
            {
                sessionList.Add(songList[choice]);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Please enter a valid option");
                FirstSong();
            }
            

            Console.Clear();
            MainMenu();
        }

        static void LastSong()
        {
            Console.WriteLine("Choose from the list of suggestions: ");
            suggestionList = songService.Search(songs, "Finisher");
            RemoveRepeats();

            AddMenuIDs();
            foreach (var song in songList)
            {
                Console.WriteLine($"{song.Key}. {song.Value.Title} ({song.Value.Type})");
            }

            var choice = Console.ReadKey().KeyChar - '0';

            if (choice > 0 && choice <= suggestionList.Count)
            {
                sessionList.Add(songList[choice]);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Please enter a valid option");
                LastSong();
            }

            Console.Clear();

            foreach (var song in sessionList)
                Console.WriteLine($"{song.Title} ({song.Type})");

            return;
        }

        static void NextSong()
        {
            Console.WriteLine("Choose from the list of suggestions: ");
            var query = sessionList.Last().Type;
            suggestionList = songService.Suggestion(songs, query);
            RemoveRepeats();

            AddMenuIDs();
            foreach (var song in songList)
            {
                Console.WriteLine($"{song.Key}. {song.Value.Title} ({song.Value.Type})");
            }

            var choice = Console.ReadKey().KeyChar - '0';

            if (choice > 0 && choice <= suggestionList.Count)
            {
                sessionList.Add(songList[choice]);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Please enter a valid option");
                NextSong();
            }

            Console.Clear();
            MainMenu();
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
