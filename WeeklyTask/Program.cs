using System;

namespace WeeklyTask
{
    class Program
    {
        private static int s_counter;
        private static  WeeklyTask[]tasks=new WeeklyTask[10];
        static void Main(string[] args)
        {
            RunInLoop();
            Console.ReadKey();
        }

        private static void RunInLoop()
        {
            string input = null;
            while (input != "exit")
            {
                PrintMenu();

                input = Console.ReadLine();

                if (int.TryParse(input, out var parsedInput))
                {
                    HandleCommand(parsedInput);

                }
                else
                {
                    Console.WriteLine("Invalid command. Try again.");
                }
            }
        }

        private static void HandleCommand(int parsedInput)
        {
            switch (parsedInput)
            {
                case 1:
                    HandleAddNewTask();
                    break;
                case 2:
                    HandleList();
                    break;
                case 3:
                    HandleEdit();
                    break;
                case 4:
                    HandleFilterByDate();
                    break;
                case 5:
                    HandleFilterByPriority();
                    break;
            }
        }

        private static void PrintMenu()
        {
            Console.WriteLine(
@"Choose a commnd:
1. Add new task.
2. List all task.
3. Edit task.
4. Filter by data.
5. Filter by priority");
        }

        private static void HandleFilterByPriority()
        {
            Console.WriteLine("HandleFilterByPriority");
        }

        private static void HandleFilterByDate()
        {
            Console.WriteLine("HandleFilterByDate");
        }

        private static void HandleEdit()
        {
            Console.WriteLine("HandleEdit"); 
        }
       private static void HandleList()
        {
            Console.WriteLine("HandleList");
        }
        private static void HandleAddNewTask()
        {
            if (s_counter > 10)
            {
                Console.WriteLine("Out of memory. Try again");
            }

            Console.WriteLine("Add task in format {}-{}-{}-{}");
            var inputData = Console.ReadLine();
            var parts = inputData?.Split(",");

            if (parts == null || parts.Length < 1 || parts.Length > 4)
            {
                Console.WriteLine("Invalid format. Try again");
                return;
            }

            if (parts.Length == 1)
            {
               
                var task = new WeeklyTask(parts[0]);
                tasks[s_counter] = task;
                s_counter++;
            }

            if (parts.Length == 2)
            {
                var date = DateTime.Parse(parts[1]);
                var task = new WeeklyTask(parts[0],date);
                tasks[s_counter] = task;
                s_counter++;
            }

            if (parts.Length == 3)
            {
                var time = DateTime.Parse(parts[2]);
                var date = DateTime.Parse(parts[1]);
                var task = new WeeklyTask(parts[0], date,time);
                tasks[s_counter] = task;
                s_counter++;
            }

            if (parts.Length == 4)
            {
                var time = DateTime.Parse(parts[2]);
                var date = DateTime.Parse(parts[1]);

                if (Enum.TryParse<Priority>(parts[3],out var priority))
                {
                    var task = new WeeklyTask(parts[0], date, time, priority);
                    tasks[s_counter] = task;
                    s_counter++;
                }
            }
        }
    }
}
