// CLASS RESPONSIBILITY: Represents a goal that is never completed but is recorded repeatedly.
// Inherits from Goal.
public class EternalGoal : Goal
{
    // EternalGoal does not need specific member variables, but it must override the behavior.
    
    // Constructor: Simply calls the base constructor.
    public EternalGoal(string name, string description, int points) : base(name, description, points)
    {
        // No specific initialization needed.
    }

    // Polymorphism: Overrides the base RecordEvent method.
    // This goal is never complete, so it just returns the points every time.
    public override int RecordEvent()
    {
        // Returns the base points every time the event is recorded.
        return _points;
    }

    // Polymorphism: Overrides the base GetStringRepresentation.
    // Since it's never complete, it always shows [ ].
    public override string GetStringRepresentation()
    {
        // Display [ ] and the goal details.
        return $"[ ] {GetDetailsString()}";
    }

    // Polymorphism: Overrides the GetDetailsString to include serialization format for saving.
    public override string GetDetailsString()
    {
        // Format: EternalGoal|Name|Description|Points
        return $"EternalGoal|{_shortName}|{_description}|{_points}";
    }
}