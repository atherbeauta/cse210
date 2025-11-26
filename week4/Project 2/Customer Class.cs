// CSE210 W04 Foundation Program 2: Encapsulation with Online Ordering
// This class represents the customer placing the order.

public class Customer
{
    // Attributes (private member variables)
    private string _name;
    // Composition: Contains an Address object
    private Address _address;

    // Constructor
    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    // Behavior: Returns whether the customer lives in the USA (delegates to the Address object)
    public bool IsInUSA()
    {
        return _address.IsInUSA();
    }

    // Accessors for shipping label
    public string GetName()
    {
        return _name;
    }

    public Address GetAddress()
    {
        return _address;
    }
}