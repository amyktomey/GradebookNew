using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GradebookNew
{
    public class Statistics
    {
        public double Average
        {
            get
            {
                return Sum / Average;
            }
        }
        public double High;
        public double Low;
        public char Letter;
        public double Sum;
        public int Count;

        public void Add(double number)
        {
            Sum += number;
            Count += 1;
            Low = Math.Min(number, Low);
            High = Math.Max(number, High);
        }

        public Statistics()
        {
            Count = 0;
            Sum = 0.0;
            High = double.MinValue;
            Low = double.MaxValue;
        }
    }
}