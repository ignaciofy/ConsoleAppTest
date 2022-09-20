using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest.Tests
{
    public class CalculateLastTime
    {
        public string CalculateTime(DateTime date, DateTime current)
        {
            string result = string.Empty;
            TimeSpan duration = date - current;

            switch (duration.TotalSeconds)
            {
                case < 60:
                    result = "now";
                    break;
                case < 3600:
                    result = $"{(int)duration.TotalMinutes} minute(s)";
                    break;
                case < 86400:
                    result = $"{(int)duration.TotalHours} hour(s)";
                    break;
                case < 604800:
                    result = $"{(int)duration.TotalDays} days(s)";
                    break;
                default:
                    result = $"{date.ToString("yyyy-MM-dd HH:mm")}";
                    break;
            }
            return result;

        }
    }
}
