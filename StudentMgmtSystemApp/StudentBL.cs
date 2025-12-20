using System;

namespace StudentMgmtSystemApp
{
    public class StudentBL
    {
       Student sObj = new Student();

       public void AcceptStudentDetails(){

         Console.ForegroundColor = ConsoleColor.Green; // 
         Console.WriteLine("  Student Management System  ");
         Console.WriteLine("------------------------------");
         
         Console.ForegroundColor = ConsoleColor.Cyan; //
         try{
            Console.WriteLine("Enter Roll No:");
         sObj.RollNo = Int32.Parse(Console.ReadLine());

         Console.WriteLine("Enter Name:");
         sObj.Name = Console.ReadLine();

         Console.WriteLine("Enter Address:");
         sObj.Address = Console.ReadLine();

        Console.WriteLine("Enter Physics Marks:");
        sObj.Phy = Int32.Parse(Console.ReadLine());

        Console.WriteLine("Enter Chemistry Marks:");
        sObj.Chem = Int32.Parse(Console.ReadLine());    

        Console.WriteLine("Enter Maths Marks:");
        sObj.Math = Int32.Parse(Console.ReadLine());
            }
        catch(Student.InvalidMarksException e){
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
         }
        catch(Exception e){
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
         }  
        Console.ForegroundColor = ConsoleColor.White;
       }

       //legacy approach 
       public int CalcTotal()
       {
        sObj.Total = sObj.Phy + sObj.Chem + sObj.Math;
        return sObj.Total;
       }

       public float CalcPerc()
       {
        sObj.Perc = (sObj.Total)/3;
        return sObj.Perc;
       }

       public void CalcResult(out int myTotal, out float myPerc)
       {
        myTotal = sObj.Phy + sObj.Chem + sObj.Math;
        myPerc = (myTotal)/3;
       }

    }
}