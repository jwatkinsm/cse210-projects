using System;

 public class ChecklistGoal : Goal
    {
        private int _amountCompleted;
        private int _target;
        private int _bonus;

        public ChecklistGoal(string name, string description, int points, int target, int bonus, int amountCompleted = 0) 
            : base(name, description, points)
        {
            _target = target;
            _bonus = bonus;
            _amountCompleted = amountCompleted;
        }
    public override int RecordEvent()
        {
            if (_amountCompleted < _target)
            {
                _amountCompleted++;
                int totalPointsEarned = GetPoints();

                // Apply milestone completion bonus
                if (_amountCompleted == _target)
                {
                    totalPointsEarned += _bonus;
                }
                return totalPointsEarned;
            }
            return 0;
        }

        public override bool IsComplete() => _amountCompleted >= _target;

        public override string GetStringRepresentation()
        {
            string statusSymbol = IsComplete() ? "[X]" : "[ ]";
            return $"{statusSymbol} {GetName()} ({GetDescription()}) -- Currently completed: {_amountCompleted}/{_target}";
        }

        public override string GetDetails()
        {
            return $"ChecklistGoal|{GetName()}|{GetDescription()}|{GetPoints()}|{_target}|{_bonus}|{_amountCompleted}";
        }
    }