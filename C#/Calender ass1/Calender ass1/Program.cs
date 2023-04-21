// See https://aka.ms/new-console-template for more information
using System;
using System.Globalization;

class MonthlyCalendar
{
    static void Main()
    {
        
        Console.WriteLine("Enter the month (1-12): ");
        int month = Convert.ToInt16(Console.ReadLine());
        Console.WriteLine("Enter the year: ");
        int year = Convert.ToInt16(Console.ReadLine());
        Console.WriteLine("Enter the day of the week for the first date of the month (0-6 where 0 is Sunday, 1 is Monday, and so on): ");
        int dayOfWeek = Convert.ToInt16(Console.ReadLine());

        
        int daysInMonth = DateTime.DaysInMonth(year, month);
        bool isLeapYear = DateTime.IsLeapYear(year);

        
        Console.WriteLine("{0} {1}", CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month), year);
        Console.WriteLine("Sun Mon Tue Wed Thu Fri Sat");

       
        for (int i = 0; i < dayOfWeek; i++)
        {
            Console.Write("    ");
        }
        for (int i = 1; i <= daysInMonth; i++)
        {
            Console.Write("{0, 4}", i);
            if ((i + dayOfWeek) % 7 == 0)
            {
                Console.WriteLine();
            }
        }

        
        int lastDayOfWeek = (dayOfWeek + daysInMonth) % 7;
        if (lastDayOfWeek != 0)
        {
            for (int i = lastDayOfWeek; i < 7; i++)
            {
                Console.Write("    ");
            }
            Console.WriteLine();
        }

       
        Console.WriteLine();

        Console.ReadLine();
    }
}

