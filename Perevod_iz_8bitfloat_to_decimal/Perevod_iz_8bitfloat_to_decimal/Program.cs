using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perevod_iz_8bitfloat_to_decimal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число в формате 1-1111-11111:");
            string input = Console.ReadLine();

            string[] parts = input.Split('-');

            if (parts.Length != 3)
            {
                Console.WriteLine("Неверный формат ввода. Используйте формат 1-1111-11111.");
                return;
            }

            string signPart = parts[0];
            string exponentPart = parts[1];
            string mantissaPart = parts[2];

            int e = Convert.ToInt32(exponentPart, 2);

            int bias = (int)Math.Pow(2, exponentPart.Length - 1) - 1;

            double mantissaValue = Convert.ToInt32(mantissaPart, 2);
            double m = 1 + mantissaValue / Math.Pow(2, mantissaPart.Length);

            double result = Math.Pow(2, e - bias) * m;

            if (signPart == "1")
            {
                result = -result;
            }

            Console.WriteLine($"Результат: {result}");
            Console.ReadKey();
        }
    }
}
