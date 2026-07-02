using System;
public class BreathingActivity : MindfulnessActivity
    {
        public BreathingActivity() : base(
            "Breathing Activity",
            "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
        {
        }

        protected override void RunActivity()
        {
            int elapsedTime = 0;
            bool breatheIn = true;

            while (elapsedTime < _duration)
            {
                Console.WriteLine(breatheIn ? "Breathe in..." : "Breathe out...");
                
                int stepTime = Math.Min(4, _duration - elapsedTime);
                ShowAnimation(stepTime);

                elapsedTime += stepTime;
                breatheIn = !breatheIn;
                Console.WriteLine();
            }
        }
    }