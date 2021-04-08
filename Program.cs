using System;

namespace ReserchigOfDays
{
    class Program
    {
        static void Main(string[] args)
        {
            DayOfWeek day;
            int daysForWeekend;

            while (true)
            {
                Console.WriteLine("Enter the day of the week . To exit, type \"q\":");

                var enterDay = Console.ReadLine();

                switch (enterDay.ToLower().Trim())
                {
                    case "mon":
                    case "monday":
                        day = DayOfWeek.Monday;
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;

                    case "tue":
                    case "tuesday":
                        day = DayOfWeek.Tuesday;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;

                    case "wed":
                    case "wednesday":
                        day = DayOfWeek.Wednesday;
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;

                    case "thu":
                    case "thursday":
                        day = DayOfWeek.Thursday;
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        break;

                    case "fri":
                    case "friday":
                        day = DayOfWeek.Friday;
                        Console.ForegroundColor = ConsoleColor.Blue;
                        break;

                    case "sat":
                    case "saturday":
                        day = DayOfWeek.Saturday;
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;

                    case "sun":
                    case "sunday":
                        day = DayOfWeek.Sunday;
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        break;

                    case "q":
                        return;
                    default:
                        Console.WriteLine("Unnamed day\n\n");
                        continue;
                }

                if (day == DayOfWeek.Sunday || day == DayOfWeek.Saturday)
                {
                    daysForWeekend = 0;
                }
                else
                {
                    daysForWeekend = 6 - (int)day;
                }

                Console.WriteLine("Full name of the day:{0} ", day);
                Console.WriteLine("Day number: {0}", day == DayOfWeek.Sunday ? day + 7 : (int)day);
                Console.WriteLine("Number of days until the weekend: {0}", daysForWeekend);

                if (DateTime.Now.DayOfWeek == day)
                {
                    Console.WriteLine("{0} is today!", day);
                }

                var offset = (7 - (int)DateTime.Now.DayOfWeek + (int)day) % 7;
                offset = offset == 0 ? 7 : offset;

                Console.WriteLine("Date of the next {0}: {1}\n\n", day, DateTime.Today.AddDays(offset).ToShortDateString());
                Console.ResetColor();   
            }
    }
    


