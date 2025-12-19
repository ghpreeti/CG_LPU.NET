using System;

namespace Day2DemoConsole
{
    public class Student
    {
    #region Fields
        int rollNo;
        string name;
        string addr;
        #endregion
    
    /// <summary>
    /// Parameterized Constructor Demo -> used to assign values to private fields of class
    /// default constructor is not created by compiler if we create parameterized constructor
    /// default constructor for student will be Student(){}
    /// </summary>
    
    public Student()
    {
        rollNo = 100;
        name = "Dummy";
        addr = "Dummy City";
    }

    public Student(int id, string name, string city)
    {
        rollNo = id;
        this.name = name;
        addr = city;
    }

    public void DisplayDetails(Student s1)
    {
        System.Console.WriteLine("RollNo :{0}\n Name : {1}\n Address : {2}",s1.rollNo,s1.name,s1.addr);
        
    }
}
}