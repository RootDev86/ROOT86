Dictionary<string, string> runtime = new();

Console.Title = "ROOT86";

while (true)
{
    Console.ForegroundColor = ConsoleColor.White;

    Console.WriteLine("ROOT86");

    Console.ForegroundColor = ConsoleColor.Gray;

    Console.Write(">_ ");

    string? input = Console.ReadLine();
    input = input?.TrimStart();

    input = input?.Trim();

    if (string.IsNullOrWhiteSpace(input))
    {
        Console.Clear();
        continue;
    }

    // FILESYSTEM
    if (input.StartsWith("fs.x01"))
    {
        FS.Read(input);
        continue;
    }

    if (input.StartsWith("fs.x02"))
    {
        FS.Delete(input);
        continue;
    }

    if (input.StartsWith("fs.x03"))
    {
        FS.Edit(input);
        continue;
    }

    // =====================================
    // LS NODE EXECUTION
    // =====================================

    if (input.StartsWith("ls."))
    {
        if (runtime.ContainsKey(input))
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.WriteLine(runtime[input]);

            Console.ForegroundColor = ConsoleColor.White;
        }

        continue;
    }

    // RUNTIME NODES
    if (input.Contains("="))
    {
        int index = input.IndexOf('=');

        string node = input.Substring(0, index).Trim();
        string value = input.Substring(index + 1).Trim();

        runtime[node] = value;

        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine($"[{node}]");
        Console.ForegroundColor = ConsoleColor.White;

        continue;
    }

    // EXECUTE NODE
    if (runtime.ContainsKey(input))
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine(runtime[input]);
        Console.ForegroundColor = ConsoleColor.White;

        continue;
    }
}
