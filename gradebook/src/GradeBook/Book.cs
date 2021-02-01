using System;
using System.Collections.Generic;

namespace GradeBook 
{
    public class Book 
    {   
        // Here Public is Access Modifier 
        public Book(string name)
        {
            // Constructor should have the same name as Class
            grades = new List<double>();
            Name = name;
        }

        public void AddGrade(double grade)
        {
            grades.Add(grade);
        }

        public Statistics GetStatistics()
        {   
            var result = new Statistics();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;
             
            foreach(var grade in grades){
                result.High = Math.Max(grade,result.High);
                result.Low = Math.Min(grade,result.Low);
                result.Average += grade; 
            }
            result.Average /= grades.Count ;
            
            return result;
        }

        //this is called as Field. Access Modifier can be added to Field
        private List<double> grades;
        public string Name;

    }
}