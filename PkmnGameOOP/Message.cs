using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PkmnGameOOP
{
    public static class Message
    {
        public static void PrintWarning(this string message)
        {
            Message.Log(message, ConsoleColor.Yellow);
        }

        public static void PrintDanger(this string message)
        {
            Log(message, ConsoleColor.Red);
        }
        public static void PrintDarkYellow(this string message)
        {
            Log(message, ConsoleColor.DarkYellow);
            
        }
        public static void PrintBlue(this string message)
        {
            Log(message, ConsoleColor.Blue);
        }
        public static void PrintDarkGreen(this string message)
        {
            Log(message, ConsoleColor.DarkGreen);
        }
        public static void PrintMagenta(this string message)
        {
            Log(message, ConsoleColor.Magenta);
        }
        public static void Log(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
