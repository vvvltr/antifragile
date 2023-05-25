using antifragile.Data.Interfaces;
using antifragile.Data.Models;

namespace antifragile.Data.Mocks;

public class MockAddresses : IAddress
{
    public List<Address> allAddresses = new List<Address>();

    public List<Address> AllAddresses
    {
        get {
            return allAddresses;
        }
        set => allAddresses = value;
    }

    public List<Address> GetUserAddresses(User user)
    {
        var userADdresses = new List<Address>();
        foreach (var var in allAddresses)
        {
            if (var.User == user)
            {
                userADdresses.Add(var);
            }
        }

        return userADdresses;
    }
}