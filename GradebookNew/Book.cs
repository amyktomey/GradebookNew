using GradebookNew;
using Microsoft.VisualBasic;
using System.Runtime.CompilerServices;

namespace GradebookNew
{
    public delegate void GradeAddedDelegate(object sneder, EventArgs args);

    public class NamedObject
    {
        public NamedObject(string name)
        {
            Name = name;
        }

        public string Name
        {
            get;
            set;
        }
    }

    public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name { get; }
        event GradeAddedDelegate GradeAdded;
    }
    
    public abstract class Book : NamedObject, IBook
    {
        public Book(string name) : base(name)
        {
        }

        public abstract event GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(double grade);

        public abstract Statistics GetStatistics();
    }

    //internal interface IBook
    //{
    //}

    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            using var writer = File.AppendText("${Name}.txt");
            writer.WriteLine(grade);
            GradeAdded?.Invoke(this, new EventArgs());
        }

        public override Statistics GetStatistics()
        {
            throw new NotImplementedException();
        }
    }

    public class InMemoryBook : Book
    {
        public InMemoryBook(string name) : base(name)
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

        public override void AddGrade(double grade)
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

        public override event GradeAddedDelegate GradeAdded;

        public override Statistics GetStatistics()
        {
            var result = new Statistics();

        
            for (var index = 0; index < grades.Count; index = index += 1)
            {
                result.Add(grades[index]);              
            }

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

         public const string CATEGORY = "Science";
    }
}

