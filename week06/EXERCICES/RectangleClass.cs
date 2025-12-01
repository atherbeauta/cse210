// Derived class for a rectangle, inheriting common properties from Shape.
public class Rectangle : Shape
{
    private double _length;
    private double _width;

    // Constructor: calls the base Shape constructor with the color
    public Rectangle(string color, double length, double width) : base(color)
    {
        _length = length;
        _width = width;
    }

    // Override the virtual GetArea method to implement the rectangle area calculation
    public override double GetArea()
    {
        return _length * _width;
    }
}