using GradebookNew;
using System.Runtime.CompilerServices;

namespace GradebookNew
{
    public delegate void GradeAddedDelegate(object sneder, EventArgs args);


    public class Book
    {
        public Book(string name)
        {
            grades = new List<double>();
            Name = name;
        }
        public void AddGrade(char letter)
        {
            switch (letter)
            {
                case 'A':
                    AddGrade(90);
                    break;

                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                case 'D':
                    AddGrade(60);
                    break;
                default:
                    AddGrade(0);
                    break;
            }
        }

        public void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }

            }
            else
            {
                throw new ArgumentException($"Invalid(nameof(grade))");
            }
        }

        public event GradeAddedDelegate GradeAdded;

        public Statistics GetStatistics()
        {
            var result = new Statistics
            {
                Average = 0.0,
                High = double.MinValue,
                Low = double.MaxValue
            };

            for (var index = 0; index < grades.Count;)
            {
                result.Low = Math.Min(grades[index], result.Low);
                result.High = Math.Max(grades[index], result.High);
                result.Average += grades[index];
                index = index += 1;
            }
            result.Average /= grades.Count;

            result.Letter = result.Average switch
            {
                var d when d >= 90.0 => 'A',
                var d when d >= 80.0 => 'B',
                var d when d >= 70.0 => 'C',
                var d when d >= 60.0 => 'D',
                _ => 'F',
            };
            return result;
        }

        private List<double> grades;

        public string Name
        {
            get;   
            set;
         }
        // public const string CATEGORY = "Science";
    }
}

