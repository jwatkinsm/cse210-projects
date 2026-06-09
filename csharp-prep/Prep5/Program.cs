using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();

        string userName = PromptUserName();
        int favoriteNumber = PromptUserNumber();

        int birthYear;
        PromptUserBirthYear(out birthYear);

        int squaredNumber = SquareNumber(favoriteNumber);

        DisplayResult(userName, squaredNumber, birthYear);
    }

    // Displays the welcome message
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    // Asks for and returns the user's name
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }

    // Asks for and returns the user's favorite number
    static int PromptUserNumber()
    {
        int number = 0;
        bool isValid = false;

        while (!isValid)
        {
            Console.Write("Please enter your favorite number: ");
            string input = Console.ReadLine();
            isValid = int.TryParse(input, out number);

            if (!isValid)
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
        }

        return number;
    }

    // Prompts for birth year and sets the out parameter
    static void PromptUserBirthYear(out int birthYear)
    {
        bool isValid = false;
        birthYear = 0;

        while (!isValid)
        {
            Console.Write("Please enter the year you were born: ");
            string input = Console.ReadLine();
            isValid = int.TryParse(input, out birthYear);

            if (!isValid)
            {
                Console.WriteLine("Invalid input. Please enter a valid year.");
            }
        }
    }

    // Calculates and returns a number squared
    static int SquareNumber(int number)
    {
        return number * number;
    }

    // Calculates age and displays final results
    static void DisplayResult(string name, int squaredNumber, int birthYear)
    {
        int currentYear = DateTime.Now.Year;
        int age = currentYear - birthYear;

        Console.WriteLine($"{name}, the square of your number is {squaredNumber}");
        Console.WriteLine($"{name}, you will turn {age} this year.");
    }
}