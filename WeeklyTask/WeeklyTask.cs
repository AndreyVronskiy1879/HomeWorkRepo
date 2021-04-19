using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeeklyTask
{
     internal class WeeklyTask
    {
        public readonly string _name;
        public readonly DateTime _date;
        public readonly DateTime _time;
     

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
        public DateTime GetDate()
        {
            return _date;
        }
        public virtual string  ConvertToString(int index)
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
            return output;
        }
    }
}
