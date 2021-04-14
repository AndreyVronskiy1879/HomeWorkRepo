using System;
using System.Collections.Generic;

namespace BusinesList
{

    enum Priority
    {
        Low,
        Medium,
        High
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<MyTask> tasks = new List<MyTask>();
            tasks.Add(new MyTask());
            tasks.Add(new MyTask("homework", DateTime.Now.AddHours(2), Priority.High));
            tasks.Add(new MyTask("go for a walk", DateTime.Now, Priority.Medium));

            tasks.Sort((a, b) => a.CompareTo(b));
            foreach (var i in tasks)
            {
                i.DisplayTask(true);
            }

        }
        class MyTask
        {
            public static int counter = 0;
            public static bool operator <(MyTask task1, MyTask task2) => task1.ndate < task2.ndate;
            public static bool operator >(MyTask task1, MyTask task2) => task1.ndate > task2.ndate;
            public static bool operator !=(MyTask task1, MyTask task2) => task1.ndate != task2.ndate;
            public static bool operator ==(MyTask task1, MyTask task2) => task1.ndate == task2.ndate;
            public static bool operator >=(MyTask task1, MyTask task2) => task1.ndate >= task2.ndate;
            public static bool operator <=(MyTask task1, MyTask task2) => task1.ndate <= task2.ndate;
            public int CompareTo(MyTask obj)
            {
                if (this > obj) return 1;
                if (this == obj) return 0;
                if (this < obj) return -1;
                return 0;
            }
            public override string ToString()
            {
                return " "+ taskNum + "; " + task + "; " + ndate + "; " + npriority + ";";
            }
            public string task { get; private set; }
            public DateTime ndate { get; private set; } = DateTime.Today.AddDays(1);
            public Priority npriority { get; private set; } = Priority.Low;
            public int taskNum { get; private set; }

            public MyTask()
            {
                taskNum = counter++;
                task = "number" + taskNum;
            }
            public MyTask(string name)
            {
                taskNum = counter++;
                task = name;
            }
            public MyTask(string name, DateTime date)
            {
                taskNum = counter++;
                task = name;
                ndate = date;
            }
            public MyTask(string name, DateTime date, Priority priority)
            {
                taskNum = counter++;
                task = name;
                ndate = date;
                npriority = priority;
            }

            public void DisplayTask()
            {
                
                Console.WriteLine($"ID {taskNum }");
                Console.WriteLine(task);
                Console.WriteLine(ndate);
                Console.WriteLine($"Priority is { npriority}\n");
               
            }

            public void DisplayTask(bool isShort)
            {
                if (isShort)
                {
                    
                    Console.WriteLine(this);
                    
                }
                else
                {
                    DisplayTask();
                }

            }

        }
    }
}
