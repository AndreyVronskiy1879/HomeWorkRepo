using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeeklyTask
{
    internal class PriorityTask : WeeklyTask
    {
        public Priority _priority;
        public PriorityTask(string name, DateTime date, DateTime time, Priority priority) : base(name, date, time)
        {
            _priority = priority;
        }
        public override string ConvertToString(int index) 
        {
            var output = $"Task № {index + 1}: {_name} ";
            if (_date != default(DateTime))
            {
                output += $"{ _date.ToShortDateString()}";
            }

            if (_time != default(DateTime))
            {
                output += $"{_time.ToShortTimeString()}";
            }

            if (_priority != Priority.Empty)
            {
                output += _priority.ToString();
            }

            return output;
        }
    }

   
}