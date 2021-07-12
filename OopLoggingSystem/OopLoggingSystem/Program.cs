using OopLoggingSystem.Library;
using System;

namespace OopLoggingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            ApplicationLog.Initialize(new FileSystemLogger(@"D:\Temp\FastTrackIT\Test"));

            int nrOfElements = ReadNumber("Please specify the number of elements", 3);
            if (nrOfElements < 0)
            {
                ApplicationLog.WriteLog(Severity.High, $"Cannot create an array having a negative size");
            }
            else
            {
                if (nrOfElements == 0)
                {
                    ApplicationLog.WriteLog(Severity.High, $"Array has no elements");
                }

                int[] array = new int[nrOfElements];
                for (int i = 0; i < nrOfElements; i++)
                {
                    int element = ReadNumber($"Element [{i}]", 3);
                    if (element < 0)
                    {
                        ApplicationLog.WriteLog(Severity.High, $"Element at index {i} was negative, using 0 instead");
                        element = 0;
                    }

                    array[i] = element;
                }

                Console.WriteLine($"Array=[{string.Join(",", array)}]");
            }

        }

        private static int ReadNumber(string label, int maxAttemptsCount, int defaultValue = 0)
        {
            label = label ?? "Please enter a number";
            int attempts = 0;
            while (attempts < maxAttemptsCount)
            {
                Console.Write($"{label}=");
                string value = Console.ReadLine();
                attempts++;

                if (int.TryParse(value, out int number))
                {
                    ApplicationLog.WriteLog(Severity.Info, $"Read number '{number}' in '{attempts}' attempts");
                    return number;
                }

                if (attempts < maxAttemptsCount)
                {
                    Console.WriteLine($"Value '{value}' doesn't represent a number, please try again ({maxAttemptsCount - attempts} attempts remaining) ...");
                }
            }

            ApplicationLog.WriteLog(Severity.Info, $"Returning default value '{defaultValue}' after '{attempts}' attempts");
            return defaultValue;
        }
    }
}
