using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using System.Diagnostics;

namespace GaleriaDavinci.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ConfigureAdb();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static void ConfigureAdb()
        {
            try
            {
                int httpPortNumber = 14097;
                using (Process process = new Process())
                {
                    process.StartInfo.FileName = $"{Environment.CurrentDirectory}\\adb\\adb.exe";
                    process.StartInfo.Arguments = $"reverse tcp:{httpPortNumber} tcp:{httpPortNumber}";
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.CreateNoWindow = true;
                    process.Start();
                }
            }
            catch
            {
                Console.WriteLine("ADB command failed");
            }
        }
    }
}
