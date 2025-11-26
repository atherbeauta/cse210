// CSE210 W04 Foundation Program 2: Encapsulation with Online Ordering
// This class represents a shipping address.

public class Address
{
    // Attributes (private member variables)
    private string _street;
    private string _city;
    private string _stateOrProvince;
    private string _country;

    // Constructor
    public Address(string street, string city, string stateOrProvince, string country)
    {
        _street = street;
        _city = city;
        _stateOrProvince = stateOrProvince;
        _country = country;
    }

    // Behavior: Returns whether the address is in the USA
    public bool IsInUSA()
    {
        // Check if the country is "USA" (case-insensitive comparison is safer)
        return _country.Equals("USA", StringComparison.OrdinalIgnoreCase);
    }

    // Behavior: Returns a formatted string with all address fields
    public string GetFullAddress()
    {
        // Use environment newline for cross-platform compatibility
        string fullAddress = $"{_street}\n{_city}, {_stateOrProvince}, {_country}";
        return fullAddress;
    }
}