using System;
using System.Collections.Generic;

namespace GradeBook
{   
   
    class Program
    {
        static void Main(string[] args)
        {
            // var book = new InMemoryBook("Rehan's Grade Book");
            IBook book = new DiskBook("Rehan's Grade Book");
            book.GradeAdded += OnGradeAdded;

            EnterGrade(book);

            var stats = book.GetStatistics();

            Console.WriteLine($"For the book Category : {InMemoryBook.CATEGORY}");
            Console.WriteLine($"For the book name : {book.Name}");
            Console.WriteLine($"The Average Grade is {stats.Average:N1} !");
            Console.WriteLine($"The Highest Grade is {stats.High:N1} !");
            Console.WriteLine($"The Lowest Grade is {stats.Low:N1} !");
            Console.WriteLine($"The Letter Grade is {stats.Letter} !");
        }

        private static void EnterGrade(IBook book)
        {
            while (true)
            {
                Console.WriteLine("Enter A Grade Or 'Q' to Quit");
                var input = Console.ReadLine();

                if (input == "Q")
                {
                    // done = true;
                    // continue;
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
                    // throw;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("**");
                }

            }
            // book.AddGrade(89.1);

        }

        static void OnGradeAdded(object sender , EventArgs e)
        {
            Console.WriteLine("A grade was added.");
        }
    }
}
