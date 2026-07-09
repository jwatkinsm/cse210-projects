using System;
public class QuestManager
    {
        private List<Goal> _goals = new List<Goal>();
        private int _score = 0;

        public void Start()
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine($"\nYou have {_score} points.\n");
                Console.WriteLine("Menu Options:");
                Console.WriteLine("1. Create New Goal");
                Console.WriteLine("2. List Goals");
                Console.WriteLine("3. Save Goals");
                Console.WriteLine("4. Load Goals");
                Console.WriteLine("5. Record Event");
                Console.WriteLine("6. Quit");
                Console.Write("Select a choice from the menu: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": CreateGoal(); break;
                    case "2": ListGoalDetails(); break;
                    case "3": SaveGoals(); break;
                    case "4": LoadGoals(); break;
                    case "5": RecordEvent(); break;
                    case "6": running = false; break;
                    default: Console.WriteLine("Invalid selection. Please choose a valid number from the menu."); break;
                }
            }
        }

        private void CreateGoal()
        {
            Console.WriteLine("\nThe types of goals are:");
            Console.WriteLine("1. Simple Goal");
            Console.WriteLine("2. Eternal Goal");
            Console.WriteLine("3. Checklist Goal");
            Console.Write("Which type of goal would you like to create? ");
            string type = Console.ReadLine();

            if (type != "1" && type != "2" && type != "3")
            {
                Console.WriteLine("Invalid goal type.");
                return;
            }

            Console.Write("What is the name of your goal? ");
            string name = Console.ReadLine();
            Console.Write("What is a short description of it? ");
            string desc = Console.ReadLine();
            
            int points = PromptForInt("What is the amount of points associated with this goal? ");

            if (type == "1")
            {
                _goals.Add(new SimpleGoal(name, desc, points));
            }
            //else if (type == "2")
           // {
           //     _goals.Add(new EternalGoal(name, desc, points));
           // }
           // else if (type == "3")
            //{
            //    int target = PromptForInt("How many times does this goal need to be accomplished for a bonus? ");
            //    int bonus = PromptForInt("What is the bonus amount for accomplishing it that many times? ");
             //   _goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
            //}
            Console.WriteLine("Goal added successfully!");
        }

        private void ListGoalDetails()
        {
            if (_goals.Count == 0)
            {
                Console.WriteLine("\nYou currently have no active goals.");
                return;
            }

            Console.WriteLine("\nYour Goals:");
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetStringRepresentation()}");
            }
        }

        private void RecordEvent()
        {
            if (_goals.Count == 0)
            {
                Console.WriteLine("\nThere are no goals available to record an event against.");
                return;
            }

            Console.WriteLine("\nThe goals are:");
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetName()}");
            }
            
            int index = PromptForInt("Which goal did you accomplish? ") - 1;

            if (index >= 0 && index < _goals.Count)
            {
                Goal selectedGoal = _goals[index];
                if (selectedGoal.IsComplete())
                {
                    Console.WriteLine("This goal is already completed!");
                    return;
                }

                int pointsEarned = selectedGoal.RecordEvent();
                _score += pointsEarned;
                Console.WriteLine($"\nCongratulations! You earned {pointsEarned} points!");
                Console.WriteLine($"Your total score is now: {_score}");
            }
            else
            {
                Console.WriteLine("Selection out of range.");
            }
        }

        private void SaveGoals()
        {
            Console.Write("Enter filename to save (e.g., goals.txt): ");
            string filename = Console.ReadLine();

            try
            {
                using (StreamWriter writer = new StreamWriter(filename))
                {
                    writer.WriteLine(_score);
                    foreach (Goal goal in _goals)
                    {
                        writer.WriteLine(goal.GetDetails());
                    }
                }
                Console.WriteLine("Goals saved successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving goals: {ex.Message}");
            }
        }

        private void LoadGoals()
        {
            Console.Write("Enter filename to load: ");
            string filename = Console.ReadLine();

            if (!File.Exists(filename))
            {
                Console.WriteLine("File not found.");
                return;
            }
            try
            {
                string[] lines = File.ReadAllLines(filename);
                if (lines.Length > 0)
                {
                    _score = int.Parse(lines[0]);
                    _goals.Clear();
                    for (int i = 1; i < lines.Length; i++)
                    {
                        if (string.IsNullOrWhiteSpace(lines[i]))continue;
                        string[] parts = lines[i].Split('|');
                        string type = parts[0];
                        if (type == "SimpleGoal")
                        {
                            _goals.Add(new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4])));
                        }
                        //else if (type == "EternalGoal")
                        //{
                        //    _goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
                        //}
                        //else if (type == "ChecklistGoal")
                        //{
                        //    _goals.Add(new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6])));
                        //}
                    }
                }
                Console.WriteLine("Goals loaded successfully!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading file data: {ex.Message}");
                }
            }
                    private int PromptForInt(string promptMessage)
                    {
                        int result;
                        while (true)
                        {
                            Console.Write(promptMessage);
                            if (int.TryParse(Console.ReadLine(), out result))
                            {
                                return result;
                            }
                            Console.WriteLine("Invalid entry. Please enter a valid whole number.");
                            }
                            }
                            }