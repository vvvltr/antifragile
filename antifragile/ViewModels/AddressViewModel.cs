using antifragile.Data.Models;

namespace antifragile.ViewModels;

public class AddressViewModel
{
    public IEnumerable<Address> Addresses;

    public string City;
    public string Street;
    public string Index;
}