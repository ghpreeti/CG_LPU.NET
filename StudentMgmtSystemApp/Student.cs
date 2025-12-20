using System;

namespace StudentMgmtSystemApp
{
    public class Student
    {

         int rollNo; //camel case
         int phy;
         int chem;    
         int math;
         int total;
         double perc;
       
       // CLR Properties - if we have some logic to implement in get/set block
       
       public int RollNo//pascal case
       {
           set { rollNo = value; }// value is a reserverd keyword
           get { return rollNo; }
          
       }

       //Auto-Implicit Property - if no logic is needed in get/set block
       public string? Name { get; set; }
       public string? Address { get; set; }

         public int Total // if get is public and set is protected these type of preoperties are called default properties
         {
            //   protected set { total = value; }
              set { total = value; }
              get { return total; }
         }

       //public int Total{get; set;}
       public float Perc { get; set; }   

       public int Phy
       {
           set { 
            if(value >= 0 && value <= 100)
                phy = value; 
            else
                throw new InvalidMarksException("Invalid Marks");
           }
           get { return phy; }
       }

         public int Chem
         {
              set
              {
                if (value >= 0 && value <= 100)
                     chem = value;
                else
                     throw new InvalidMarksException("Invalid Marks");
              }
              get { return chem; }
         }

            public int Math
            {
                set
                {
                    if (value >= 0 && value <= 100)
                        math = value;
                    else
                        throw new InvalidMarksException("Invalid Marks");
                }
                get { return math; }
            }







       [Serializable]
       public class InvalidMarksException : Exception
       {
           public InvalidMarksException()
           {
           }

           public InvalidMarksException(string message)
               : base(message)
           {
           }

           public InvalidMarksException(string message, Exception inner)
               : base(message, inner)
           {
           }
       }

    }
}