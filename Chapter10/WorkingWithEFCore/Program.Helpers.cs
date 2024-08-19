using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


partial class Program
{
    static void SectionTitle(string title)
    {
        ConsoleColor previousColor = ConsoleColor.Yellow;
        ForegroundColor = ConsoleColor.Yellow;

        WriteLine("*");
        WriteLine($"* {title}");
        WriteLine("*");

        ForegroundColor = previousColor;
    }

    static void Fail(string message)
    {
        ConsoleColor previousColor = ForegroundColor;
        ForegroundColor = ConsoleColor.Red;
        WriteLine($"Fail > {message}");
        ForegroundColor = previousColor;
    }
    static void Info(string message)
    {
        ConsoleColor previousColor = ForegroundColor;
        ForegroundColor = ConsoleColor.Cyan;
        WriteLine($"Info > {message}");
        ForegroundColor = previousColor;
    }
}
