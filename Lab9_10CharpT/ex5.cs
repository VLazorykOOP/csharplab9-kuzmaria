using System;
using System.Collections.Generic;

class Song
{
    public string Title { get; set; }
    public string Artist { get; set; }

    public Song(string title, string artist)
    {
        Title = title;
        Artist = artist;
    }

    public override string ToString()
    {
        return $"Пісня: {Title}, Виконавець: {Artist}";
    }
}

class MusicDisc
{
    public string Name { get; set; }
    private List<Song> songs;

    public MusicDisc(string name)
    {
        Name = name;
        songs = new List<Song>();
    }

    public void AddSong(Song song) => songs.Add(song);
    public void RemoveSong(string title) =>
        songs.RemoveAll(s => s.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
    public List<Song> GetSongs() => songs;

    public override string ToString()
    {
        string result = $"Диск: {Name}\n";
        if (songs.Count == 0)
            result += "  (немає пісень)\n";
        else
            foreach (var song in songs)
                result += "  " + song + "\n";
        return result;
    }
}

class ex5
{
    private static Dictionary<string, MusicDisc> catalog = new();

    public static void Process()
    {
        while (true)
        {
            Console.WriteLine("\nКаталог музичних дисків:");
            Console.WriteLine("1. Додати диск");
            Console.WriteLine("2. Видалити диск");
            Console.WriteLine("3. Додати пісню на диск");
            Console.WriteLine("4. Видалити пісню з диска");
            Console.WriteLine("5. Переглянути весь каталог");
            Console.WriteLine("6. Переглянути диск");
            Console.WriteLine("7. Пошук пісень виконавця");
            Console.WriteLine("0. Вийти");
            Console.Write("Ваш вибір: ");
            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1": AddDisc(); break;
                case "2": RemoveDisc(); break;
                case "3": AddSong(); break;
                case "4": RemoveSong(); break;
                case "5": ViewCatalog(); break;
                case "6": ViewDisc(); break;
                case "7": SearchByArtist(); break;
                case "0": return;
                default: Console.WriteLine("Невірний вибір."); break;
            }
        }
    }

    private static void AddDisc()
    {
        Console.Write("Введіть назву диска: ");
        string? name = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(name)) return;

        if (!catalog.ContainsKey(name))
        {
            catalog[name] = new MusicDisc(name);
            Console.WriteLine("✅ Диск додано.");
        }
        else
        {
            Console.WriteLine("⚠️ Такий диск уже існує.");
        }
    }

    private static void RemoveDisc()
    {
        Console.Write("Введіть назву диска: ");
        string? name = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(name)) return;

        if (catalog.Remove(name))
            Console.WriteLine("✅ Диск видалено.");
        else
            Console.WriteLine("⚠️ Диск не знайдено.");
    }

    private static void AddSong()
    {
        Console.Write("На який диск додати пісню? ");
        string? discName = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(discName)) return;

        if (catalog.TryGetValue(discName, out MusicDisc? disc))
        {
            Console.Write("Назва пісні: ");
            string? title = Console.ReadLine();
            Console.Write("Виконавець: ");
            string? artist = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(title) && !string.IsNullOrWhiteSpace(artist))
            {
                disc.AddSong(new Song(title, artist));
                Console.WriteLine("✅ Пісню додано.");
            }
        }
        else
        {
            Console.WriteLine("⚠️ Диск не знайдено.");
        }
    }

    private static void RemoveSong()
    {
        Console.Write("З якого диска видалити пісню? ");
        string? discName = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(discName)) return;

        if (catalog.TryGetValue(discName, out MusicDisc? disc))
        {
            Console.Write("Назва пісні: ");
            string? title = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(title))
            {
                disc.RemoveSong(title);
                Console.WriteLine("✅ Пісню видалено (якщо вона була).");
            }
        }
        else
        {
            Console.WriteLine("⚠️ Диск не знайдено.");
        }
    }

    private static void ViewCatalog()
    {
        if (catalog.Count == 0)
        {
            Console.WriteLine("📁 Каталог порожній.");
            return;
        }

        foreach (var entry in catalog.Values)
        {
            Console.WriteLine(entry.ToString());
        }
    }

    private static void ViewDisc()
    {
        Console.Write("Введіть назву диска: ");
        string? name = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(name)) return;

        if (catalog.TryGetValue(name, out MusicDisc? disc))
        {
            Console.WriteLine(disc.ToString());
        }
        else
        {
            Console.WriteLine("⚠️ Диск не знайдено.");
        }
    }

    private static void SearchByArtist()
    {
        Console.Write("Введіть ім’я виконавця для пошуку: ");
        string? artist = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(artist)) return;

        bool found = false;
        foreach (var disc in catalog.Values)
        {
            foreach (var song in disc.GetSongs())
            {
                if (song.Artist.Equals(artist, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"[{disc.Name}] {song}");
                    found = true;
                }
            }
        }
        
        if (!found)
        {
            Console.WriteLine("🔍 Пісень цього виконавця не знайдено.");
        }
    }
}
