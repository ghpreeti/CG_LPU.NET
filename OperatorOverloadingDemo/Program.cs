// See https://aka.ms/new-console-template for more information
using OperatorOverloadingDemo;

Console.WriteLine("Hello, World!");

int num1 = 100;
int num2 = 100;

int numRes = num1 + num2;
Console.WriteLine(numRes);

Employee emp1  = new Employee();
emp1.EmpID = 101;
emp1.EmpName = "test1";
emp1.Salary = 1;


Employee emp2 = new Employee();
emp2.EmpID = 104;
emp2.EmpName = "test2";
emp2.Salary = 2;

Employee emp3 = new Employee();
emp3.EmpID = 109;
emp3.EmpName = "test3";
emp3.Salary = 3;

Employee empObj = emp1 + emp2+emp3;
System.Console.WriteLine($"Total Salary {empObj.Salary}");

