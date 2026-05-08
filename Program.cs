using System;

Console.Title = "ROOT86";

while (true)
{
    Console.ForegroundColor = ConsoleColor.White;

    Console.WriteLine("ROOT86");

    Console.ForegroundColor = ConsoleColor.Gray;

    Console.Write(">_ ");

    string? input = Console.ReadLine();

    input = input?.Trim();

    if (string.IsNullOrWhiteSpace(input))
    {
        Console.Clear();
        continue;
    }

    Parser.Parse(input);
}
