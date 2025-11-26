// CSE210 W04 Foundation Program 2: Encapsulation with Online Ordering
// This class manages the products, customer, and final pricing/labels.

public class Order
{
    // Attributes (private member variables)
    // Composition: Contains a list of Product objects and a Customer object
    private List<Product> _products;
    private Customer _customer;

    // Constructor
    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    // Behavior: Adds a product to the order list
    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    // Behavior: Calculates the subtotal of all products in the order
    private float GetSubtotal()
    {
        float subtotal = 0;
        foreach (Product product in _products)
        {
            subtotal += product.GetTotalCost();
        }
        return subtotal;
    }

    // Behavior: Calculates the shipping cost based on the customer's location
    public float GetShippingCost()
    {
        // Shipping cost logic: $5 for USA, $35 otherwise.
        if (_customer.IsInUSA())
        {
            return 5.00f; // $5.00 for US shipping
        }
        else
        {
            return 35.00f; // $35.00 for international shipping
        }
    }

    // Behavior: Calculates the final total price (subtotal + shipping)
    public float GetTotalCost()
    {
        float subtotal = GetSubtotal();
        float shippingCost = GetShippingCost();
        
        return subtotal + shippingCost;
    }

    // Behavior: Returns a string for the packing label
    public string GetPackingLabel()
    {
        string label = "--- PACKING LABEL ---\n";
        foreach (Product product in _products)
        {
            label += $"Name: {product.GetName()} | ID: {product.GetProductId()}\n";
        }
        label += "----------------------";
        return label;
    }

    // Behavior: Returns a string for the shipping label
    public string GetShippingLabel()
    {
        string label = "--- SHIPPING LABEL ---\n";
        label += $"Customer: {_customer.GetName()}\n";
        
        // Get the formatted address from the Address object
        label += _customer.GetAddress().GetFullAddress();
        label += "\n----------------------";
        return label;
    }
}