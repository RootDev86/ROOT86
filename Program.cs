Dictionary<string, string> runtime = new();

Console.Title = "ROOT86";

while (true)
{
    Console.ForegroundColor = ConsoleColor.White;

    Console.WriteLine("ROOT86");

    Console.ForegroundColor = ConsoleColor.Gray;

    Console.Write(">_ ");

    string? input = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(input))
    {
        Console.Clear();
        continue;
    }

    input = input.Trim();

    // VALUE ASSIGN
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
    // RUNTIME EXECUTION
    if (runtime.ContainsKey(input.Trim()))
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;

        Console.WriteLine(runtime[input.Trim()]);

        Console.ForegroundColor = ConsoleColor.White;

        continue;
    }
    }

    // AUTO CREATE UNKNOWN NODE
    runtime[input] = "null";
}
