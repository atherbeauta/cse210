// Derived class for a square, inheriting common properties from Shape.
public class Square : Shape
{
    private double _side;

    // Constructor: calls the base Shape constructor with the color
    public Square(string color, double side) : base(color)
    {
        _side = side;
    }

    // Override the virtual GetArea method to implement the square area calculation
    public override double GetArea()
    {
        return _side * _side;
    }
}