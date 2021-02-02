using System;
using System.Collections.Generic;
using System.IO;

namespace GradeBook 
{   
    public delegate void GradeAddedDelegate(object sender, EventArgs args );

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
        string Name {get;}
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

    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            using(var writer = File.AppendText($"{Name}.txt"))
            {
                writer.WriteLine(grade);
                if(GradeAdded != null)
                {
                    GradeAdded(this , new EventArgs());
                }
            }
            // writer.Dispose();
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            using (var reader = File.OpenText($"{Name}.txt"))
            {
                var line = reader.ReadLine();
                while(line != null)
                {
                    var number = double.Parse(line);
                    result.Add(number);
                    line = reader.ReadLine();
                }
            }

            return result;
        }
    }

    public class InMemoryBook : Book
    {   
        // Here Public is Access Modifier 
        public InMemoryBook(string name) : base(name)
        {
            // Constructor should have the same name as Class
            // category = "";
            grades = new List<double>();
            Name = name;
        }

        // public void AddLetterGrade(char letter)
        // {
        //     switch (letter)
        //     {
        //         case 'A':
        //             AddGrade(90);
        //             break;
        //         case 'B':
        //             AddGrade(80);
        //             break;
                    
        //         case 'C':
        //             AddGrade(70);
        //             break;

        //         default: 
        //             AddGrade(0);
        //             break;
        //     }
        // }

        public override void AddGrade(double grade)
        {   
            if(grade <= 100 && grade >= 0){
                grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }

        public override event GradeAddedDelegate GradeAdded;

        public override Statistics GetStatistics()
        {   
            var result = new Statistics();
           
            for(var index = 0; index < grades.Count ; index ++)
            {   
                result.Add(grades[index]); 
            } 
            
            return result;
        }

        //this is called as Field. Access Modifier can be added to Field
        private List<double> grades;
        // public string Name 
        // {
            // get
            // {
            //     return name;
            // }
            // set
            // {   
            //     if(!String.IsNullOrEmpty(value))
            //     {
            //         name = value ;
            //     }
            // }

            //Auto Property
            // get;
            //private set; //Inaccessible name from BOOk.cs ie after book is made name cannot be change
            // set;
        // }
        // private string name;

        // readonly string category = "Science";
        public const string CATEGORY = "Science";
    }
}