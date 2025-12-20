// See https://aka.ms/new-console-template for more information
using Day3Demo;

public class Program
{
    public static void Main(string[] args)
    {
        Person p1 = new Person();
        p1.Display(100);
        p1.Display(100.25f);
        p1.Display("LPU");
        p1.Display(new Employee());

        Employee employee = null;// while the time of declaration put null to overcome overhead

        employee = new Employee();// we only initilize it when we need it
    }

    }

