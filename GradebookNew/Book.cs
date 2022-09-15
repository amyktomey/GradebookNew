namespace Gradebook2
{ 
    public class Book
    {
        public Book(string name)
        {
            grades = new List<double>();
            this.name = name;
        }

    public void AddGrade(double grade)
    {
        if (grade <= 100 && grade >= 0)
        {
            grades.Add(grade);
        }
        else
        {
            Console.WriteLine("Invalid value");
        }
    }

    public Statistics GetStatistics()
        {
            var result = new Statistics
            {
                Average = 0.0,
                High = double.MinValue,
                Low = double.MaxValue
            };

            for ( var index = 0; index < grades.Count; )
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
        public string name;

        public IEnumerable<char> Name { get; set; }
    }
}

