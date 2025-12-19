// See https://aka.ms/new-console-template for more information
using Day2DemoConsole;

static void Menu()
{
    System.Console.WriteLine("1. Add Student details");
    System.Console.WriteLine("2. Display Student details");
    System.Console.WriteLine("3. Exit"); 
}

Console.WriteLine("Hello, World!");
Student sObj = new Student(123,"Alok","Delhi"); //Parameterized constructor called

// System.Console.WriteLine(123,"Alok","Delhi");
sObj.DisplayDetails(sObj);

sObj=new Student(123,"Alok","Chennai");
sObj.DisplayDetails(sObj);

String[] cities = {"Delhi","Mumbai","Chennai","Kolkata","Bangalore"};

foreach(string city in cities)
{
    System.Console.WriteLine(city);
}

int choice = 0;
do
{
    Menu();
    System.Console.WriteLine("Enter your choice");
    choice = Int32.Parse(Console.ReadLine());
} while(true);

