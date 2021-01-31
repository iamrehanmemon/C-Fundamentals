using System;
using System.Collections.Generic;

namespace GradeBook 
{
    class Book 
    {   
        // Here Public is Access Modifier 
        public Book(string name)
        {
            // Constructor should have the same name as Class
            grades = new List<double>();
            this.name = name;
        }

        public void AddGrade(double grade)
        {
            grades.Add(grade);
        }

        public void ShowStatistics()
        {
            var result = 0.0 ;
            var highGrade = double.MinValue;
            var lowGrade = double.MaxValue;
            
            foreach(var number in grades){
                highGrade = Math.Max(number,highGrade);
                lowGrade = Math.Min(number,lowGrade);
                result += number ;
            }

            var avg = result/grades.Count;
            Console.WriteLine($"The Average Grade is {avg:N1} !");
            Console.WriteLine($"The Highest Grade is {highGrade:N1} !");
            Console.WriteLine($"The Lowest Grade is {lowGrade:N1} !");
        }

        //this is called as Field. Access Modifier can be added to Field
        private List<double> grades;
        private string name;

    }
}