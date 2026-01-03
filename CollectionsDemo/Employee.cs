using System;

namespace CollectionsDemo
{
    public class Employee : IComparable<Employee>
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
        public int Exp { get; set; }

        // Default sorting by ID
        public int CompareTo(Employee other)
        {
            return this.ID.CompareTo(other.ID);
        }
    }
}
