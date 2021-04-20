using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeeklyTask
{
    delegate void GetMessage(string message);
    delegate void WriteOutput(string text);
    delegate string ReadInput();
    
    internal class WeeklyTaskService
    {
        GetMessage _mes= GetMessageAboutUpdateTask;
        WriteOutput _writeOutput;
        ReadInput _readInput=()=>Console.ReadLine();
        private  int _counter;
        private readonly WeeklyTask[] _tasks = new WeeklyTask[10];
        public void RegisterExchanger(WriteOutput writeOutput)
        {
            _writeOutput = writeOutput;
        }
        public void HandleAddNewTask()
        {
            if (_counter > 10)
            {
                if (_writeOutput != null)
                {
                    _writeOutput("Out of memory. Try again");
                } 
            }
            if (_writeOutput != null)
            {
                _writeOutput("Add task in format {}-{}-{}-{}");
            }
            
            var inputData = _readInput();
            var task =ParseNewTask(inputData);
            AddNewTask(task);
        }
        public void HandleFilterByPriority()
        {
            if (_writeOutput != null)
            {
                _writeOutput("HandleFilterByPriority");
            }
        }

        public void HandleFilterByDate()
        {
            if (_writeOutput != null)
            {
                _writeOutput("Input date:");
            }

            var inputDate = _readInput();
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
            var inputNumber = _readInput();
            var taskNumber = int.Parse(inputNumber);

            Console.WriteLine("Input new task data.");
            var inputTaskData = _readInput();
            _mes(inputNumber);
            WeeklyTask task = ParseNewTask(inputTaskData);
            _tasks[taskNumber - 1] = task;
        }

        private static void GetMessageAboutUpdateTask(string inputNumber)
        {
            Console.WriteLine($"Task # {inputNumber} has been updated");
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
            
            return new RegularTask(parts[0]);
            
        }
        private WeeklyTask CreateTaskWithNameandDate(string[] parts)
        {
            var date = DateTime.Parse(parts[1]);
            return new RegularTask(parts[0], date);
            
        }
        private WeeklyTask CreateTaskWithNameDateTime(string[] parts)
        {
            
            var (date,time)= ParseDateTime(parts);
            return new RegularTask(parts[0], date, time);
            
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
