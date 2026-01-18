using System;
using System.Collections.Generic;

namespace CalculateNumbers
{
public class Program{
public static List<int>NumberList = new List<int>();

public static void AddNumbers(int Numbers){
NumberList.Add(Numbers);
}

public static double GetGPAScores(){
double GPA = 0.0;
if(NumberList==null){
return -1;
}
else{
foreach(var item in NumberList){
GPA += item*3;
}
}
return GPA/NumberList.Count;
}

public static char GetGradeScore(double gpa){
 	if (gpa == 10.0)
                return 'S';
            else if (gpa >= 9.0 && gpa<10.0)
                return 'A';
            else if (gpa >= 8.0 && gpa<9.0)
                return 'B';
            else if (gpa >= 7.0 && gpa<8.0)
                return 'C';
            else if (gpa >= 5.0 && gpa<7.0)
                return 'D';
            else
                return 'E';
}

public static void Main(){
  Console.WriteLine("Enter number of values:");
  int n = int.Parse(Console.ReadLine());

  Console.WriteLine("Enter numbers:");
  for (int i = 0; i < n; i++)
  {
     int num = int.Parse(Console.ReadLine());
     AddNumbers(num);
  }
  double gpa = GetGPAScores();

    if (gpa == -1)
   {
       Console.WriteLine("No numbers available");
   }
   else
   {
     char grade = GetGradeScore(gpa);
     Console.WriteLine($"GPA Score: {gpa}");
     Console.WriteLine($"Grade: {grade}");
   }
}

}
}