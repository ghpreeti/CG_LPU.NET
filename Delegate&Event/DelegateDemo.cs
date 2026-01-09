using System;
using System.Collections.Generic;
using System.Text;

namespace Delegate_Event
{
    //multicast delegate as its return type is void Unicast must have return type
    public delegate void GreetMsg(string msg);

    class Hindi
    {
        public void WelcomeMsg(String userName)
        {
            Console.WriteLine("Suprabhat " + userName);
        }

    }
    class English
    {
        public void WelcomeMsg(String userName)
        {
            Console.WriteLine("Welcome " + userName);
        }

    }
    class Tamil
    {
        public void WelcomeMsg(String userName)
        {
            Console.WriteLine("Vanakkam " + userName);
        }

    }
    public class DelegateDemo
    {
       static void DelegateDemoMain()
        {
            Tamil tObj = new Tamil();
            GreetMsg GreetInTamil = new GreetMsg(tObj.WelcomeMsg);
        }

    }
}
