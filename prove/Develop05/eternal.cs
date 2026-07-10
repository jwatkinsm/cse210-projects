using System;
 public class EternalGoal : Goal
    {
        public override bool IsComplete() => false; // Eternal goals are never finished

        public EternalGoal(string name, string description, int points) 
            : base(name, description, points) { }

        public override int RecordEvent()
        {
            return GetPoints();
        }

        public override string GetStringRepresentation()
        {
            return $"[ ] {GetName()} ({GetDescription()})";
        }

        public override string GetDetails()
        {
            return $"EternalGoal|{GetName()}|{GetDescription()}|{GetPoints()}";
        }
    }