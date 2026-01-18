using System;
using System.Collections;

namespace YogaMeditation
{
public class Program{
public static ArrayList memberList = new ArrayList();

public static void AddYogaMember(int memberId, int age, double weight, double height,string goal){
 MeditationCenter member = new MeditationCenter();
       member.MemberId = memberId;
       member.Age = age;
       member.Weight = weight;
       member.Height = height;
       member.Goal = goal;

       memberList.Add(member);
}

public static double CalculateBMI(int memberId){
 foreach(MeditationCenter member in memberList){
	if(member.MemberId == memberId){
           return member.Weight/(member.Height*member.Height);
	}
 }
	return -1;
}

public static int CalculateYogaFee(int memberId){
 foreach (MeditationCenter member in memberList)
 {
     if (member.MemberId == memberId)
     {
      double bmi = CalculateBMI(memberId);
	if (member.Goal == "Weight Loss" && bmi >= 25 && bmi < 30)
              return 2000;
        else if (member.Goal == "Weight Loss" && bmi >= 30 && bmi < 35)
              return 2500;
        else if (member.Goal == "Weight Loss" && bmi >= 35)
              return 3000;
        else if (member.Goal == "Weight Gain")
              return 2500;
        else
              return -1;
   }
}
      return -1;
}


public static void Main()
{
    Console.WriteLine("Enter number of members:");
    int n = int.Parse(Console.ReadLine());

    for (int i = 0; i < n; i++)
    {
        Console.WriteLine("\nEnter Member Details");

        Console.Write("Member Id: ");
        int memberId = int.Parse(Console.ReadLine());

        Console.Write("Age: ");
        int age = int.Parse(Console.ReadLine());

        Console.Write("Weight (kg): ");
        double weight = double.Parse(Console.ReadLine());

        Console.Write("Height (meters): ");
        double height = double.Parse(Console.ReadLine());

        Console.Write("Goal (Weight Loss / Weight Gain): ");
        string goal = Console.ReadLine();

        AddYogaMember(memberId, age, weight, height, goal);
    }

    Console.Write("\nEnter MemberId to calculate BMI and Fee: ");
    int searchId = int.Parse(Console.ReadLine());

    double bmi = CalculateBMI(searchId);
    int fee = CalculateYogaFee(searchId);

    if (bmi == -1)
    {
        Console.WriteLine("Member not found");
    }
    else
    {
        Console.WriteLine($"BMI: {bmi:F2}");
        Console.WriteLine($"Yoga Fee: {fee}");
    }
}
}
}