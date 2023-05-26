using antifragile.Data.Interfaces;
using antifragile.Data.Models;
using Newtonsoft.Json;

namespace antifragile.Data.Mocks;

public class MockAddresses : IAddress
{
    private readonly string Pathstr = @"C:\Users\Владислава\RiderProjects\antifragile\antifragile\Data\Addresses.json";
    public List<Address> AllAddresses
    {
        get
        {
            string json = File.ReadAllText(Pathstr);
            var addresses = JsonConvert.DeserializeObject<List<Address>>(json);
            return addresses;
        }
        set => AllAddresses = value;
    }

    public List<Address> GetUserAddresses(User user)
    {
        var userADdresses = new List<Address>();
        foreach (var var in AllAddresses)
        {
            if (var.UserID == user.id)
            {
                userADdresses.Add(var);
            }
        }
        return userADdresses;
    }

    public void AddAddress(Address address)
    {
        List<Address> currAddresses = new List<Address>(AllAddresses);
        currAddresses.Add(address);

        string serializeAddresses = JsonConvert.SerializeObject(currAddresses);
        File.WriteAllText(Pathstr, serializeAddresses);
    }
}