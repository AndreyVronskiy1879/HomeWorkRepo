using System;

namespace WeeklyTask
{
    class Program
    {
        private static WeeklyTaskService s_service = new WeeklyTaskService();
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
                    s_service.HandleAddNewTask();
                    break;
                case 2:
                    s_service.HandleList();
                    break;
                case 3:
                    s_service.HandleEdit();
                    break;
                case 4:
                    s_service.HandleFilterByDate();
                    break;
                case 5:
                    s_service. HandleFilterByPriority();
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
    }
}
