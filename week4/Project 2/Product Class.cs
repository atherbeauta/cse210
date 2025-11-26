// CSE210 W04 Foundation Program 2: Encapsulation with Online Ordering
// This class represents a single product in an order.

public class Product
{
    // Attributes (private member variables)
    private string _name;
    private string _productId;
    private float _price;
    private int _quantity;

    // Constructor
    public Product(string name, string productId, float price, int quantity)
    {
        _name = name;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }

    // Behavior: Calculates the total cost for this product (price * quantity)
    public float GetTotalCost()
    {
        return _price * _quantity;
    }

    // Accessors for packing label
    public string GetName()
    {
        return _name;
    }

    public string GetProductId()
    {
        return _productId;
    }
}