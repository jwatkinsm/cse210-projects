using System;

class Program
{
    static void Main(string[] args)
      {
        // 1. Initialize the scripture and reference
        Reference reference = new Reference("Proverbs", 3, 5, 6);
        string text = "Trust in the LORD with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.";
        
        Scripture scripture = new Scripture(reference, text);

        // 2. Main loop
        while (!scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            
            Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit:");
            string input = Console.ReadLine();

            if (input.Trim().Equals("quit", StringComparison.OrdinalIgnoreCase))
            {
                break;
            }

            // Hide 3 words at a time
            scripture.HideRandomWords(3);
        }

        // Final screen
        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("\nProgram complete.");
    }
}