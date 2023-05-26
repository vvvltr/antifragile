using antifragile.Data.Models;

namespace antifragile.ViewModels;

public class AddressViewModel
{
    public IEnumerable<Address> Addresses { get; set; }

    public string City { get; set; }
    public string Street { get; set; }
    public string Index { get; set; }
}