// CLASS RESPONSIBILITY: Represents a goal that must be accomplished a specific number of times.
// Inherits from Goal.
public class ChecklistGoal : Goal
{
    // Encapsulation: Specific attributes for ChecklistGoal.
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    // Constructor: Calls the base constructor and initializes specific attributes.
    public ChecklistGoal(string name, string description, int points, int target, int bonus) : base(name, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    // Overload Constructor for Loading (includes current progress)
    public ChecklistGoal(string name, string description, int points, int target, int bonus, int amountCompleted) : base(name, description, points)
    {
        _amountCompleted = amountCompleted;
        _target = target;
        _bonus = bonus;
    }

    // Polymorphism: Overrides the base RecordEvent method.
    // Handles incremental points and the final bonus.
    public override int RecordEvent()
    {
        // Increment the count
        _amountCompleted++;
        
        // Award the base points
        int totalPoints = _points;

        // Check if the goal is complete
        if (_amountCompleted == _target)
        {
            totalPoints += _bonus;
            Console.WriteLine($"\n*** CONGRATULATIONS! You completed the goal '{_shortName}' and earned a bonus! ***");
        }
        
        return totalPoints;
    }

    // Polymorphism: Overrides the base GetDetailsString to include the progress.
    public override string GetDetailsString()
    {
        // Display the progress: (Currently Completed/Total Target)
        return $"{_shortName} ({_description}) -- Currently completed: {_amountCompleted}/{_target}";
    }

    // Polymorphism: Overrides the base GetStringRepresentation to show completion status and progress.
    public override string GetStringRepresentation()
    {
        // Display [X] if complete, or [ ] if incomplete.
        string status = _amountCompleted >= _target ? "[X]" : "[ ]";
        
        // Format: [X] Name (Description) -- Currently completed: 3/5
        return $"{status} {GetDetailsString()}";
    }

    // Override the serialization string for saving/loading.
    public override string GetDetailsString()
    {
        // Format: ChecklistGoal|Name|Description|Points|Bonus|Target|AmountCompleted
        return $"ChecklistGoal|{_shortName}|{_description}|{_points}|{_bonus}|{_target}|{_amountCompleted}";
    }
}