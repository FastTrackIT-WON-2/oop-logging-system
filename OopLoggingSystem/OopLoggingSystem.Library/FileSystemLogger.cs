using System;
using System.IO;
using System.Text;

namespace OopLoggingSystem.Library
{
    public class FileSystemLogger : Logger
    {
        public override void Write(Severity severity, string message)
        {
            StringBuilder logEntryBuilder = new StringBuilder();
            logEntryBuilder.AppendLine(new string('-', Console.WindowWidth - 1));
            logEntryBuilder.AppendLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}][{severity}] - {message}");
            logEntryBuilder.AppendLine(new string('-', Console.WindowWidth - 1));

            using (StreamWriter outputFile = new StreamWriter(@"D:\Temp\FastTrackIT\error.txt", append: true))
            {
                outputFile.WriteLine(logEntryBuilder.ToString());
            }
        }
    }
}
