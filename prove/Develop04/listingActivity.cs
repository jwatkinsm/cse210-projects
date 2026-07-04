 public class ListingActivity : MindfulnessActivity
    {
        private List<string> _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt peace or inspiration this month?",
            "Who are some of your personal heroes?"
        };

        private Random _random = new Random();

        public ListingActivity() : base(
            "Listing Activity",
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
        {
        }

        protected override void RunActivity()
        {
            string selectedPrompt = _prompts[_random.Next(_prompts.Count)];
            Console.WriteLine($"\nCategory: {selectedPrompt}");
            ShowAnimation(5, "Get ready to list as many items as you can in...");

            Console.WriteLine("\nBegin typing your items! Press Enter after each item.");
            Console.WriteLine($"You have {_duration} seconds. Go!");

            List<string> items = new List<string>();
            DateTime startTime = DateTime.Now;

            // Track time dynamically while capturing console entries
            while ((DateTime.Now - startTime).TotalSeconds < _duration)
            {
                int timeLeft = _duration - (int)(DateTime.Now - startTime).TotalSeconds;
                if (timeLeft <= 0) break;

                Console.Write($"Time remaining: {timeLeft}s > ");
                
                // Read input safely if available
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    items.Add(input);
                }
            }

            Console.WriteLine("\nTime is up!");
            Console.WriteLine($"You successfully listed {items.Count} items in this category!");
            Thread.Sleep(3000);
        }
    }