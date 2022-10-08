using GradebookNew;

namespace GradebookNew
{
    class Program
    {
        public static void Main(string[] args)
        {
            var book = new Book("Amy's Grade Book");
            book.GradeAdded += OneGradeAdded;

            var done = false;

            while (true)
            {
                Console.WriteLine("Enter a grade or 'q' to quit:");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }

                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                   // Console.WriteLine(" Bye-bye!");
                }
            }

            var stats = book.GetStatistics();

            // Console.WriteLine(Book.CATEGORY);
            Console.WriteLine($"For the book named: {book.Name}:"); 
            Console.WriteLine($"The lowest grade is {stats.Low}.");
            Console.WriteLine($"The highest grade is {stats.High}.");
            Console.WriteLine($"The average grade is {stats.Average:N1}.");
            Console.WriteLine($"The letter grade is {stats.Letter}.");
        }

        static void OneGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added");
        }
    }
}