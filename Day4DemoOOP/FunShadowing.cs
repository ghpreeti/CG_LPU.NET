using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4DemoOOP
{ 

    public class Base
{
    public virtual void Display()
    {
        Console.WriteLine("Base Display Method");
    }
}

//single inheritance with method overriding
public class Derived : Base
{
    public override void Display()
    {
        Console.WriteLine("Derived Display Method");
    }

}



public class FunShadowing
    {
        public static void Shadow()
    {
        Base b = new Base();
        Derived d = new Derived();
        Base bd = new Derived();
    }
}

}
