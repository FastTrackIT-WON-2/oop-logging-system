using System;
using System.Text;

namespace OopLoggingSystem.Library
{
    public class ConsoleLogger : Logger
    {
        public override void Write(Severity severity, string message)
        {
            StringBuilder logEntryBuilder = new StringBuilder();
            logEntryBuilder.AppendLine(new string('-', Console.WindowWidth - 1));
            logEntryBuilder.AppendLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}][{severity}] - {message}");
            logEntryBuilder.AppendLine(new string('-', Console.WindowWidth - 1));

            switch (severity)
            {
                case Severity.Info:
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(logEntryBuilder.ToString());
                    Console.ResetColor();
                    break;

                case Severity.Warning:
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine(logEntryBuilder.ToString());
                    Console.ResetColor();
                    break;

                case Severity.High:
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(logEntryBuilder.ToString());
                    Console.ResetColor();
                    break;

                case Severity.Critical:
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(logEntryBuilder.ToString());
                    Console.ResetColor();
                    break;
            }
        }
    }
}
