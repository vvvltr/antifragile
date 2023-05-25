using antifragile.Data.Models;

namespace antifragile.Data.Interfaces;

public interface IAddress
{
    public List<Address> AllAddresses { get; set; }
    public List<Address> GetUserAddresses(User user);
}