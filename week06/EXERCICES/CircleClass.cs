using System;

// Derived class for a circle, inheriting common properties from Shape.
public class Circle : Shape
{
    private double _radius;

    // Constructor: calls the base Shape constructor with the color
    public Circle(string color, double radius) : base(color)
    {
        _radius = radius;
    }

    // Override the virtual GetArea method to implement the circle area calculation
    public override double GetArea()
    {
        // Area of a circle is Pi * r^2
        return Math.PI * _radius * _radius;
    }
}