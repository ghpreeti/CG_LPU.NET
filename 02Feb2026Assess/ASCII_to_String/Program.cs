// See https://aka.ms/new-console-template for more information
using System;
using System.Text;

class Program
{
    public static string CleanseAndInvert(string input)
    {
        if (string.IsNullOrEmpty(input) ||input.Length < 6)
        {
            return "";
        }
        foreach (char c in input)
        {
           
            if (!char.IsLetter(c))
            {
                return "";
            }
        }

        input = input.ToLower();
        StringBuilder str = new StringBuilder();
        foreach(var c in input)
        {
            if((int)c % 2 != 0)
            {
                str.Append(c);
            }
        }
        char[] arr = str.ToString().ToCharArray();
        Array.Reverse(arr);


        for (int i = 0; i < arr.Length; i++)
        {
        
            if (i % 2 == 0)
            {
                char.ToUpper(arr[i]);
            }
            else
            {
                char.ToLower(arr[i]);
            }

        }
        return new string(arr);

    }
    static void Main()
    {
        if (CleanseAndInvert("Preeti") == "")
        {
            Console.WriteLine("Invalid Input");
        }
        else
        {
            Console.WriteLine($"The generated key is - {CleanseAndInvert("Preeti")}");
        }
    }

}