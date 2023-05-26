using antifragile.Data.Models;

namespace antifragile.ViewModels;

public class ProfileViewModel
{
    public string Name;
    public string Email;
    public string Password;
    public string PhoneNumber;
    
    public List<Address> Addresses;

    public AddressViewModel AddressViewModel;
}