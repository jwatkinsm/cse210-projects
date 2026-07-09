  using System;
  public class SimpleGoal : Goal
    {
        private bool _isComplete;

        public SimpleGoal(string name, string description, int points, bool isComplete = false) 
            : base(name, description, points)
        {
            _isComplete = isComplete;
        }

        public override int RecordEvent()
        {
            if (!_isComplete)
            {
                _isComplete = true;
                return GetPoints();
            }
            return 0; 
        }

        public override bool IsComplete() => _isComplete;

        public override string GetStringRepresentation()
        {
            string statusSymbol = _isComplete ? "[X]" : "[ ]";
            return $"{statusSymbol} {GetName()} ({GetDescription()})";
        }

        public override string GetDetails()
        {
            return $"SimpleGoal|{GetName()}|{GetDescription()}|{GetPoints()}|{_isComplete}";
        }
    }
