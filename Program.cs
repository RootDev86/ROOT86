Dictionary<string, string> nodes = new();

Console.Title = "ROOT86";

while (true)
{
    Console.ForegroundColor = ConsoleColor.White;

    Console.WriteLine("ROOT86");

    Console.ForegroundColor = ConsoleColor.Cyan;

    Console.Write(">_ ");

    Console.ForegroundColor = ConsoleColor.White;

    string? input = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(input))
    {
        Console.Clear();
        continue;
    }

    input = input.Trim();

    // EXIT
    if (input == "exit")
    {
        break;
    }

    // CLEAR
    if (input == "clear")
    {
        Console.Clear();
        continue;
    }

    // HELP
    if (input == "help")
    {
        Console.WriteLine("help");
        Console.WriteLine("clear");
        Console.WriteLine("exit");
        Console.WriteLine("node.create X");
        Console.WriteLine("node.list");
        Console.WriteLine("fs.list");
        continue;
    }

    // NODE CREATE
    if (input.StartsWith("node.create "))
    {
        string node = input.Replace("node.create ", "");

        nodes[node] = "null";

        continue;
    }

    // NODE VALUE
    if (input.Contains("="))
    {
        string[] parts = input.Split("=");

        if (parts.Length == 2)
        {
            string node = parts[0].Trim();
            string value = parts[1].Trim();

            nodes[node] = value;
        }

        continue;
    }

    // NODE LIST
    if (input == "node.list")
    {
        foreach (var node in nodes)
        {
            Console.WriteLine($"{node.Key} = {node.Value}");
        }

        continue;
    }

    // FS LIST
    if (input == "fs.list")
    {
        foreach (var dir in Directory.GetDirectories("."))
        {
            Console.WriteLine(dir);
        }

        foreach (var file in Directory.GetFiles("."))
        {
            Console.WriteLine(file);
        }

        continue;
    }

    Console.WriteLine("unknown");
}
