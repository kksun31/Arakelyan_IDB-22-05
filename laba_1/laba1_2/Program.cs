using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            IDateTimeFormatter dateTimeFormatter;
            AmericanDateTime americanDateTime = new AmericanDateTime();
            EuropeanDateTime europeanDateTime = new EuropeanDateTime();

            Console.WriteLine($"Американский формат: {americanDateTime.FormatDateTime()}");
            Console.WriteLine($"Европейский формат: {europeanDateTime.FormatDateTime()}");
            Console.WriteLine();

            dateTimeFormatter = new EuropeanDateTime();

            dateTimeFormatter = new SymbolDateTimeDecorator(dateTimeFormatter, "Окс");
            dateTimeFormatter = new SymbolDateTimeDecorator(dateTimeFormatter, "Ара");

            Console.WriteLine($"Декоратор: {dateTimeFormatter.FormatDateTime()}");
        }
    }
}