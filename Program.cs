using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        string command = "whoami"; // Example PowerShell command

        Process process = new Process();
        process.StartInfo.FileName = "powershell.exe";
        process.StartInfo.Arguments = $"-Command \"{command}\"";
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.RedirectStandardError = true;
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.CreateNoWindow = true;

        process.Start();

        // Read the output
        string output = process.StandardOutput.ReadToEnd();
        string error = process.StandardError.ReadToEnd();

        process.WaitForExit();

        Console.WriteLine("Output:\n" + output);
        if (!string.IsNullOrWhiteSpace(error))
        {
            Console.WriteLine("Error:\n" + error);
        }
    }
}
