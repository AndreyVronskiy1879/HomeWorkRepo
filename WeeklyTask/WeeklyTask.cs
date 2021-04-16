using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeeklyTask
{
     internal class WeeklyTask
    {
        private readonly string _name;
        private readonly DateTime _date;
        private readonly DateTime _time;
        private readonly Priority _priority;

        public WeeklyTask(string name)
        {
            this._name = name;
        }

        public WeeklyTask(string name,DateTime date)
        {
            this._name = name;
            this._date = date;
        }

        public WeeklyTask(string name, DateTime date,DateTime time)
        {
            this._name = name;
            this._date = date;
            this._time = time;
        }

        public WeeklyTask(string name, DateTime date, DateTime time, Priority priority)
        {
            this._name = name;
            this._date = date;
            this._time = time;
            this._priority = priority;
        }
        public DateTime GetDate()
        {
            return _date;
        }
        public string ConvertToString(int index)
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
