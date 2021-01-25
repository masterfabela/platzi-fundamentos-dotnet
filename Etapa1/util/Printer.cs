using static System.Console;

namespace SchoolCore.Util
{
    public static class Printer
    {
        public static void PrintLine(int size = 20)
        {
            var linea = "".PadRight(size, '=');
            WriteLine(linea);
        }

        public static void PrintTitle(string title)
        {
            PrintLine(title.Length + 4);
            WriteLine($"| {title} |");
            PrintLine(title.Length + 4);
        }

        public static void Beep(int hz = 2000, int time = 500, int cuantity = 1)
        {
            while (cuantity-- > 0)
            {
                System.Console.Beep(hz, time);
            }
        }
    }
}