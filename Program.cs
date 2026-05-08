using System.Diagnostics;

Console.Title = "ROOT86";

Console.ForegroundColor = ConsoleColor.Red;

Dictionary<string, string> nodes = new();

Console.WriteLine("ROOT86 RUNTIME v0.2");
Console.WriteLine("FILESYSTEM LINKED");
Console.WriteLine();

while (true)
{
    Console.Write("ROOT86 > ");

    string? input = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(input))
        continue;

    if (input == "exit")
        break;

    if (input == "clear")
    {
        Console.Clear();
        continue;
    }

    if (input == "help")
    {
        Console.WriteLine("help");
        Console.WriteLine("clear");
        Console.WriteLine("exit");
        Console.WriteLine("node.list");
        Console.WriteLine("node.create X");
        Console.WriteLine("fs.list");
        Console.WriteLine("fs.make X");
        Console.WriteLine("pkg.install X");
        continue;
    }

    if (input == "node.list")
    {
        foreach (var node in nodes)
        {
            Console.WriteLine($"{node.Key} = {node.Value}");
        }

        continue;
    }

    if (input.StartsWith("node.create "))
    {
        string nodeName = input.Replace("node.create ", "");

        nodes[nodeName] = "0";

        Console.WriteLine($"created node: {nodeName}");

        continue;
    }

    if (input.Contains("=="))
    {
        string[] parts = input.Split("==");

        if (parts.Length == 2)
        {
            string node = parts[0].Trim();
            string value = parts[1].Trim();

            nodes[node] = value;

            Console.WriteLine($"updated {node} = {value}");
        }

        continue;
    }

    if (input == "fs.list")
    {
        string[] dirs = Directory.GetDirectories(".");

        foreach (string dir in dirs)
        {
            Console.WriteLine(dir);
        }

        continue;
    }

    if (input.StartsWith("fs.make "))
    {
        string folder = input.Replace("fs.make ", "");

        Directory.CreateDirectory(folder);

        Console.WriteLine($"directory created: {folder}");

        continue;
    }

    if (input.StartsWith("pkg.install "))
    {
        string package = input.Replace("pkg.install ", "");

        Process proc = new();

        proc.StartInfo.FileName = "/bin/sh";
        proc.StartInfo.Arguments = $"-c \"apk add {package}\"";

        proc.StartInfo.UseShellExecute = false;

        proc.Start();

        proc.WaitForExit();

        Console.WriteLine($"package injected: {package}");

        continue;
    }

    Console.WriteLine($"unknown node: {input}");
}
