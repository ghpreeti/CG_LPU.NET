using System;
using System.Collections.Generic;
using System.Text;

namespace PersonDetails
{
    internal class PersonImplementation
    {
        public string GetName(IList<Person> person)
        {
            string str = String.Empty;
            foreach(var item in person)
            {
                str += item.Name + "-"+item.Address+"\n";
            }
            return str;
        }

        public double Average(IList<Person> person)
        {
            double sum = 0;
            double count = person.Count();
            foreach(var item in person)
            {
                sum+= item.Age;
            }
            return sum/count;
        }

        public int Max(IList<Person> person)
        {
            return person.Max(p => p.Age);
        }
    }
}
