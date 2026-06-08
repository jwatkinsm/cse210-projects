using System;
using System.Diagnostics.CodeAnalysis;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep1 World!");

        Console.Write("What is your first name?");
        string first= Console.ReadLine();

        Console.Write("What is your last name?");
        string last= Console.ReadLine();

        Console.WriteLine($"So, your name is {last}, {first} {last}.");
    }
}