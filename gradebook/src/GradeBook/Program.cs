using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            // double x = 6.4;
            // double y = 6.4;
            // double z = x+y;
            // Console.WriteLine(z);
            // Console.WriteLine("Hello "+ args[0] + "!");

            // numbers[0] = 12.3 ;
            // numbers[1] = 12.9 ;
            // numbers[2] = 12.6 ;
            // var numbers = new double[] {12.3,12.9,12.6,12.5};
            var numbers = new [] {12.3,12.9,12.6,12.5};
            // List<double> grades = new List<double>();
            var grades = new List<double>() {12.3,12.9,12.6,12.5};
            grades.Add(56.1);
         

            var result = 0.0 ;
            foreach(double number in grades){
                result += number ;
            }
            var avg = result/grades.Count;
            Console.WriteLine($"The Average Grade is {avg} !");

            if (args.Length > 0){
                Console.WriteLine($"Hello, {args[0]} !");
            }
            else {
                Console.WriteLine($"Hello !");
            }
        
        }
    }
}
