# FS.cs

```csharp
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
```

---

# Program.cs

Оставь только это:

```csharp
Dictionary<string, string> runtime = new();

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
```

---

# После этого

```bash
dotnet run
```

Работает:

```text
fs.x01 = "test.txt"
fs.x02 = "test.txt"
fs.x03 = "test.txt"
```
