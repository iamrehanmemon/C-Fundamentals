using System;
using System.Collections.Generic;

namespace GradeBook
{   
   
    class Program
    {
        static void Main(string[] args)
        {   
            var book = new Book("Rehan's Grade Book");
            // var done= false;

            // while(!done)
            while(true)
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
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    // throw;
                }
                catch(FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("**");
                }
                
            }
            // book.AddGrade(89.1);
            // book.AddGrade(90.5);
            // book.AddGrade(77.5);
            
            var stats = book.GetStatistics();     

            
            Console.WriteLine($"The Average Grade is {stats.Average:N1} !");
            Console.WriteLine($"The Highest Grade is {stats.High:N1} !");
            Console.WriteLine($"The Lowest Grade is {stats.Low:N1} !");
            Console.WriteLine($"The Letter Grade is {stats.Letter} !");
        }
    }
}
