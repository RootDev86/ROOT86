using System;
using System.Collections.Generic;

namespace ROOT86
{
    public static class Commands
    {
        public static Dictionary<string, RuntimeNode> Nodes =
            new Dictionary<string, RuntimeNode>();

        static Commands()
        {
            // =====================
            // CORE
            // =====================

            Add("ls.0x01", "shell");
            Add("ls.0x02", "parser");
            Add("ls.0x03", "exec");

            // =====================
            // FILESYSTEM
            // =====================

            Add("ls.1x01", "root");
            Add("ls.1x02", "home");
            Add("ls.1x03", "logs");

            // =====================
            // APPLICATIONS
            // =====================

            Add("ls.2x01", "chrome");
            Add("ls.2x02", "editor");

            // =====================
            // NETWORK
            // =====================

            Add("ls.3x01", "proxy");
            Add("ls.3x02", "dns");

            // =====================
            // DISPLAY
            // =====================

            Add("ls.4x01", "pixel");
            Add("ls.4x02", "render");

            // =====================
            // PROCESS
            // =====================

            Add("ls.5x01", "process");
            Add("ls.5x02", "thread");

            // =====================
            // MEMORY
            // =====================

            Add("ls.6x01", "cache", 512);
            Add("ls.6x02", "ram", 8192);

            // =====================
            // HARDWARE
            // =====================

            Add("ls.7x01", "gpu");
            Add("ls.7x02", "audio");
            Add("ls.7x03", "usb");

            // =====================
            // MUTATION
            // =====================

            Add("ls.8x01", "drift");
            Add("ls.8x02", "corrupt");

            // =====================
            // PACKAGES
            // =====================

            Add("ls.9x01", "install");
            Add("ls.9x02", "launch");
            Add("ls.9x03", "remove");

            // =====================
            // SECURITY
            // =====================

            Add("ls.ax01", "auth");
            Add("ls.ax02", "firewall");

            // =====================
            // CHAOS
            // =====================

            Add("ls.bx01", "collapse");
            Add("ls.bx02", "fracture");
        }

        static void Add(
            string path,
            string name,
            int value = 1)
        {
            Nodes[path] = new RuntimeNode
            {
                Path = path,
                Name = name,
                Value = value
            };
        }

        public static void Execute(ParsedCommand command)
        {
            switch (command.Operator)
            {
                case ".?":
                    Query(command);
                    break;

                case ".==":
                    Modify(command);
                    break;

                case ".=":
                    ExecutePath(command);
                    break;

                case ".//":
                    Install(command);
                    break;
            }
        }

        static void Query(ParsedCommand command)
        {
            if (Nodes.ContainsKey(command.Path))
            {
                Console.WriteLine(
                    Nodes[command.Path].Value
                );
            }
        }

        static void Modify(ParsedCommand command)
        {
            if (Nodes.ContainsKey(command.Path))
            {
                if (int.TryParse(command.Payload, out int value))
                {
                    Nodes[command.Path].Value = value;

                    // filesystem death

                    if (command.Path == "ls.1x01" && value == 0)
                    {
                        FilesystemSystem.DestroyRoot();
                    }

                    // gpu death

                    if (command.Path == "ls.7x01" && value == 0)
                    {
                        HardwareSystem.DisableGPU();
                    }

                    // chaos

                    if (command.Path.StartsWith("ls.bx"))
                    {
                        ChaosSystem.RuntimeCollapse();
                    }

                    Console.WriteLine(
                        $"{command.Path} => {value}"
                    );
                }
            }
        }

        static void ExecutePath(ParsedCommand command)
        {
            if (command.Path == "ls.9x02")
            {
                PackageSystem.Launch(command.Payload);
            }
        }

        static void Install(ParsedCommand command)
        {
            if (command.Path == "ls.9x01")
            {
                PackageSystem.Install(command.Payload);
            }
        }
    }
}
