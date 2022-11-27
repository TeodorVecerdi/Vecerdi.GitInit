using System.Diagnostics;

namespace Vecerdi.GitInit;

internal static class CommandHelper {
    public static void Run(string command, string arguments = "", bool dry = false) {
        if (!dry) {
            Process process = new() {
                StartInfo = new ProcessStartInfo {
                    FileName = command,
                    Arguments = arguments,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };
            process.Start();
            process.WaitForExit();
        }

        Console.WriteLine($"[CMD] {command} {arguments}");
    }
}