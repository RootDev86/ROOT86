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
        string[] parts = input.Split("=");

        if (parts.Length == 2)
        {
            string node = parts[0].Trim();
            string value = parts[1].Trim();

            runtime[node] = value;
        }

        continue;
    }

    // RUNTIME EXECUTION
    if (runtime.ContainsKey(input))
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;

        Console.WriteLine(runtime[input]);

        Console.ForegroundColor = ConsoleColor.White;

        continue;
    }

    // AUTO CREATE UNKNOWN NODE
    runtime[input] = "null";
}
