using System;
using System.Collections.Generic;

namespace GradeBook
{   
   
    class Program
    {
        static void Main(string[] args)
        {   
            // Book book2 = new Book();
            // Book book2 = null;
            // book2.AddGrade(90.1);
            var book = new Book("Rehan's Grade Book");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.5);
            book.ShowStatistics();  
            
        }
    }
}
