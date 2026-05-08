using System;
using System.Diagnostics;

namespace ROOT86
{
    public static class PackageSystem
    {
        public static void Install(string package)
        {
            Console.WriteLine(
                $"installing {package}"
            );

            Process process = new Process();

            process.StartInfo.FileName = "sh";

            process.StartInfo.Arguments =
                $"-c \"sudo apk add {package}\"";

            process.StartInfo.UseShellExecute = false;

            process.Start();

            process.WaitForExit();
        }

        public static void Launch(string package)
        {
            Process.Start(package);
        }
    }
}
