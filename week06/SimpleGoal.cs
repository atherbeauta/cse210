// CLASS RESPONSIBILITY: Represents a goal that can only be completed once.
// Inherits from Goal.
public class SimpleGoal : Goal
{
    // Encapsulation: Specific attribute for SimpleGoal.
    private bool _isComplete;

    // CONSTRUCTOR 1 (For Creation): Calls the base constructor and sets the initial state to false.
    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {
        // SimpleGoal starts as incomplete.
        _isComplete = false;
    }

    // CONSTRUCTOR 2 (For Loading): Accepts the existing completion state from the saved file.
    public SimpleGoal(string name, string description, int points, bool isComplete) : base(name, description, points)
    {
        _isComplete = isComplete;
    }

    // Polymorphism: Overrides the base RecordEvent method.
    // Returns the points gained only if the goal was not already complete.
    public override int RecordEvent()
    {
        if (_isComplete)
        {
            Console.WriteLine($"\nYou already completed the goal '{_shortName}'. No points awarded.");
            return 0;
        }

        _isComplete = true;
        // Returns the base points for completing the goal.
        return _points;
    }

    // Polymorphism: Overrides the base GetStringRepresentation to show completion status.
    public override string GetStringRepresentation()
    {
        // Display [X] if complete, or [ ] if incomplete.
        string status = _isComplete ? "[X]" : "[ ]";
        return $"{status} {base.GetDetailsString()}";
    }

    // Override the serialization string for saving/loading.
    public override string GetDetailsString()
    {
        // Format: SimpleGoal|Name|Description|Points|isComplete
        return $"SimpleGoal|{_shortName}|{_description}|{_points}|{_isComplete}";
    }
}