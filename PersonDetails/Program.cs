// See https://aka.ms/new-console-template for more information
using System;
using PersonDetails;

class Program
{
       static void Main(string[] args)
    {
        try
        {
            var persons = new List<Person>
            {
                new Person { Name = "Aarya", Address = "123 Main St", Age = 69 },
                new Person { Name = "Daniel", Address = "456 Oak Ave", Age = 40 },
                new Person { Name = "Ira", Address = "789 Pine Rd", Age = 25 },
                new Person { Name = "Jennifer", Address = "321 Maple Ln", Age = 33 }
            };
            var personImpl = new PersonImplementation();
            var namesAndAddresses = personImpl.GetName(persons);
            Console.WriteLine("Names and Addresses:");
            Console.WriteLine(namesAndAddresses);
            var averageAge = personImpl.Average(persons);
            Console.WriteLine($"Average Age: {averageAge}");
            var maxAge = personImpl.Max(persons);
            Console.WriteLine($"Max Age: {maxAge}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

}