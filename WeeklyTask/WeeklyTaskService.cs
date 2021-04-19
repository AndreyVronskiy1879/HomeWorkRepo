using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeeklyTask
{
    internal class WeeklyTaskService
    {
        private  int _counter;
        private readonly WeeklyTask[] _tasks = new WeeklyTask[10];
        public void HandleAddNewTask()
        {
            if (_counter > 10)
            {
                Console.WriteLine("Out of memory. Try again");
            }

            Console.WriteLine("Add task in format {}-{}-{}-{}");
            var inputData = Console.ReadLine();
            var task =ParseNewTask(inputData);
            AddNewTask(task);
        }
        public void HandleFilterByPriority()
        {
            Console.WriteLine("HandleFilterByPriority");
        }

        public void HandleFilterByDate()
        {
            Console.WriteLine("Input date:");
            var inputDate = Console.ReadLine();
            var date = DateTime.Parse(inputDate);
           
            for(int i=0;i<_counter; i++)
            {
                var task = _tasks[i];
                if (_tasks[i].GetDate() >= date)
                {
                    PrintTask(i, task);
                }
            }
        }

        private static void PrintTask(int i, WeeklyTask task)
        {
            Console.WriteLine(task.ConvertToString(i));
        }

        public void HandleEdit()
        {
            Console.WriteLine("Input number to edit:");
            var inputNumber = Console.ReadLine();
            var taskNumber = int.Parse(inputNumber);
            
            Console.WriteLine("Input new task data.");
            var inputTaskData = Console.ReadLine();
            WeeklyTask task=ParseNewTask(inputTaskData);
            _tasks[taskNumber - 1] = task;
           
        }
        public void HandleList()
        {
            for (int i = 0; i < _counter; i++)
            {
                var task = _tasks[i];
                PrintTask(i, task);
            }
        }

        private WeeklyTask ParseNewTask(string inputData)
        {
            var parts = inputData?.Split(",");

            if (parts == null || parts.Length < 1 || parts.Length > 4)
            {
                Console.WriteLine("Invalid format. Try again");
                return null;
            }

            return CreateNewTask(parts);
        }

        private WeeklyTask CreateNewTask(string[] parts)
        {
            switch (parts.Length)
            {
                case 1:
                    return CreateTaskWithName(parts);                   
                case 2:
                    return CreateTaskWithNameandDate(parts);                    
                case 3:
                    return CreateTaskWithNameDateTime(parts);                  
                case 4:
                    return CreateTaskWithNameDAteTimePriority(parts);
                default:
                    return null;
            }
        }


        private  WeeklyTask CreateTaskWithName(string[] parts)
        {
            
            return new WeeklyTask(parts[0]);
            
        }
        private WeeklyTask CreateTaskWithNameandDate(string[] parts)
        {
            var date = DateTime.Parse(parts[1]);
            return new WeeklyTask(parts[0], date);
            
        }
        private WeeklyTask CreateTaskWithNameDateTime(string[] parts)
        {
            
            var (date,time)= ParseDateTime(parts);
            return new WeeklyTask(parts[0], date, time);
            
        }
        private WeeklyTask CreateTaskWithNameDAteTimePriority(string[] parts)
        {
            var (date, time) = ParseDateTime(parts);
            var priority = Enum.Parse<Priority>(parts[3]);
                return new PriorityTask(parts[0], date, time, priority);
        }
        private static (DateTime date, DateTime time) ParseDateTime(string[] parts)
        {
            var time = DateTime.Parse(parts[2]);
            var date = DateTime.Parse(parts[1]);
            return (date, time);
        }
        private  void AddNewTask(WeeklyTask task)
        {
            _tasks[_counter] = task;
            _counter++;
        }
    }
}
