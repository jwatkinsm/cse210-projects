 using System;

 public class ReflectionActivity : MindfulnessActivity
    {
        private List<string> _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        private List<string> _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        private Random _random = new Random();

        public ReflectionActivity() : base(
            "Reflection Activity",
            "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have.")
        {
        }

        protected override void RunActivity()
        {
            string selectedPrompt = _prompts[_random.Next(_prompts.Count)];
            Console.WriteLine($"\nPrompt: {selectedPrompt}");
            ShowAnimation(5, "Take a moment to think about this prompt...");

            int elapsedTime = 5; // Account for the initial 5-second reflection delay

            while (elapsedTime < _duration)
            {
                string question = _questions[_random.Next(_questions.Count)];
                Console.WriteLine($"\nReflect on: {question}");

                int stepTime = Math.Min(5, _duration - elapsedTime);
                ShowAnimation(stepTime, "Thinking... (simulating spinner)...");

                elapsedTime += stepTime;
            }
        }
    }