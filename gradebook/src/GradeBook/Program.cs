using System;
using System.Collections.Generic;

namespace GradeBook
{   
   
    class Program
    {
        static void Main(string[] args)
        {   
            var book = new Book("Rehan's Grade Book");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.5);
            
            var stats = book.GetStatistics();     

            
            Console.WriteLine($"The Average Grade is {stats.Average:N1} !");
            Console.WriteLine($"The Highest Grade is {stats.High:N1} !");
            Console.WriteLine($"The Lowest Grade is {stats.Low:N1} !");
        }
    }
}
