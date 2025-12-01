// The base class for all geometric shapes.
public class Shape
{
    // Private member variable for color (Encapsulation)
    private string _color;

    // Constructor to initialize the common attribute
    public Shape(string color)
    {
        _color = color;
    }

    // Getter method to provide controlled access to the color
    public string GetColor()
    {
        return _color;
    }

    // Virtual method to be overridden by derived classes (Polymorphism setup)
    // The base implementation returns 0.0 as a generic shape has no specific area.
    public virtual double GetArea()
    {
        return 0.0;
    }
}