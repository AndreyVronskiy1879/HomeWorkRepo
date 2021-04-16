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
            var parts = inputData?.Split(",");

            if (parts == null || parts.Length < 1 || parts.Length > 4)
            {
                Console.WriteLine("Invalid format. Try again");
                return;
            }

            HandleAddNewTask(parts);
        }

        private void HandleAddNewTask(string[] parts)
        {
            if (parts.Length == 1)
            {
                AddNewTaskWithName(parts);
            }

            if (parts.Length == 2)
            {
                AddNewTaskWithDate(parts);
            }

            if (parts.Length == 3)
            {
                AddNewTaskWithDateTime(parts);
            }

            if (parts.Length == 4)
            {
                AddNewTaskWithDateTimeAndPriority(parts);
            }
        }

        public void HandleFilterByPriority()
        {
            Console.WriteLine("HandleFilterByPriority");
        }

        public void HandleFilterByDate()
        {
            Console.WriteLine("HandleFilterByDate");
        }

        public void HandleEdit()
        {
            Console.WriteLine("HandleEdit");
        }
        public void HandleList()
        {
            for(int i = 0; i < _counter; i++)
            {
                var task = _tasks[i];
                Console.WriteLine(task.ConvertToString());
            }
        }
        private  void AddNewTaskWithName(string[] parts)
        {
            var task = new WeeklyTask(parts[0]);
            AddNewTask(task);
        }
        private  void AddNewTaskWithDate(string[] parts)
        {
            var date = DateTime.Parse(parts[1]);
            var task = new WeeklyTask(parts[0], date);
            AddNewTask(task);
        }
        private  void AddNewTaskWithDateTime(string[] parts)
        {
            var time = DateTime.Parse(parts[2]);
            var date = DateTime.Parse(parts[1]);
            var task = new WeeklyTask(parts[0], date, time);
            AddNewTask(task);
        }
        private  void AddNewTaskWithDateTimeAndPriority(string[] parts)
        {
            var time = DateTime.Parse(parts[2]);
            var date = DateTime.Parse(parts[1]);

            if (Enum.TryParse<Priority>(parts[3], out var priority))
            {
                var task = new WeeklyTask(parts[0], date, time, priority);
                AddNewTask(task);
            }
        }
        private  void AddNewTask(WeeklyTask task)
        {
            _tasks[_counter] = task;
            _counter++;
        }
    }
}
