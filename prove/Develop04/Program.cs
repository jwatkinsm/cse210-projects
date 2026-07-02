using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== MINDFULNESS APP ===");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");
            Console.Write("Select an option (1-4): ");

            string choice = Console.ReadLine();
            MindfulnessActivity activity = null;

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ReflectionActivity();
                    break;
                case "3":
                    activity = new ListingActivity();
                    break;
                case "4":
                    Console.WriteLine("Goodbye. Take care of yourself!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    Thread.Sleep(1000);
                    continue;
            }

            activity.ShowActivity();
        }
    }
}
