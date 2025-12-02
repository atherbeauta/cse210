// CLASS RESPONSIBILITY: Base class for all types of goals.
// This class ensures all goals share common properties and behaviors.
// It is marked abstract because a generic 'Goal' cannot be instantiated directly.
public abstract class Goal
{
    // Encapsulation: All shared member variables are private or protected.
    protected string _shortName;
    protected string _description;
    protected int _points;

    // Base Constructor
    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    // This method is required by all derived classes, but the implementation is specific
    // to each type of goal (Simple, Eternal, Checklist).
    // Polymorphism: Declared abstract to force implementation in derived classes.
    public abstract int RecordEvent();

    // This method provides the default display string for the goal itself.
    // Polymorphism: Declared virtual so derived classes can override it if needed.
    public virtual string GetDetailsString()
    {
        return $"{_shortName} ({_description})";
    }

    // This method determines the display string for the list, showing completion status.
    public abstract string GetStringRepresentation();

    // Simple getter for the base points (used by the manager for display)
    public string GetName()
    {
        return _shortName;
    }

    // Get the points awarded when the event is recorded.
    public int GetPoints()
    {
        return _points;
    }
}