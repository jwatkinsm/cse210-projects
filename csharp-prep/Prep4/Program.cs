using System;

class Program
{
    static void Main(string[] args)
    {
     List<int> numbers = new List<int>();
        int input;

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        // Core Requirement: Get numbers and append to list
        do
        {
            Console.Write("Enter number: ");
            input = int.Parse(Console.ReadLine());
            
            if (input != 0)
            {
                numbers.Add(input);
            }
        } while (input != 0);

        if (numbers.Count > 0)
        {
            
            int sum = numbers.Sum();
            double average = numbers.Average();
            int max = numbers.Max();

            Console.WriteLine($"The sum is: {sum}");
            Console.WriteLine($"The average is: {average}");
            Console.WriteLine($"The largest number is: {max}");

          
            var positiveNumbers = numbers.Where(n => n > 0);
            if (positiveNumbers.Any())
            {
                int smallestPositive = positiveNumbers.Min();
                Console.WriteLine($"The smallest positive number is: {smallestPositive}");
            }
            else
            {
                Console.WriteLine("The smallest positive number is: N/A (no positive numbers entered)");
            }

           
            numbers.Sort();
            Console.WriteLine($"The sorted list is: {string.Join(" ", numbers)}");
        }
        else
        {
            Console.WriteLine("No numbers were entered.");
        }
    }
}