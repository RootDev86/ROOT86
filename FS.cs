using System;
using System.IO;

public static class FS
{
    public static void Read(string input)
    {
        string path = ExtractPath(input);

        if (File.Exists(path))
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(File.ReadAllText(path));
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    public static void Delete(string input)
    {
        string path = ExtractPath(input);

        if (File.Exists(path))
        {
            File.Delete(path);

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("[deleted]");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    public static void Edit(string input)
    {
        string path = ExtractPath(input);

        if (!File.Exists(path))
        {
            File.Create(path).Close();
        }

        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine(File.ReadAllText(path));
        Console.ForegroundColor = ConsoleColor.White;

        Console.Write("edit > ");

        string? content = Console.ReadLine();

        File.WriteAllText(path, content ?? "");
    }

    private static string ExtractPath(string input)
    {
        int index = input.IndexOf('=');

        if (index == -1)
            return "";

        string value = input.Substring(index + 1).Trim();

        value = value.Replace("\"", "");

        return value;
    }
}
