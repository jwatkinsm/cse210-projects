using System; 

public abstract class MindfulnessActivity
{
    protected string _name;
    protected string _description;
    protected int _duration;

     public MindfulnessActivity(string name, string description)
        {
            _name = name;
            _description = description;
            _duration = 0;
        }
//animation
         protected void ShowAnimation(int seconds, string message = "")
        {
            if (!string.IsNullOrEmpty(message))
            {
                Console.WriteLine(message);
            }

            for (int i = seconds; i > 0; i--)
            {
                Console.Write($"...{i}");
                Thread.Sleep(1000);
            }
            Console.WriteLine();
        }

         protected void StartMessage()
        {
            Console.Clear();
            Console.WriteLine($"--- {_name.ToUpper()} ---");
            Console.WriteLine(_description);
            Console.WriteLine();

            while (true)
            {
                Console.Write("Enter the duration of the activity in seconds: ");
                if (int.TryParse(Console.ReadLine(), out int result) && result > 0)
                {
                    _duration = result;
                    break;
                }
                Console.WriteLine("Invalid input. Please enter a positive whole number.");
            }

            Console.WriteLine();
            ShowAnimation(3, "Prepare to begin...");
        }

        protected void EndMessage()
        {
            Console.WriteLine("\nGreat job!");
            ShowAnimation(3, $"Wrapping up your {_name}...");
            Console.WriteLine($"You have successfully completed {_duration} seconds of {_name}!");
            ShowAnimation(3, "Returning to main menu...");
        }

         public void ShowActivity()
        {
            StartMessage();
            RunActivity();
            EndMessage();
        }
        protected abstract void RunActivity();
}