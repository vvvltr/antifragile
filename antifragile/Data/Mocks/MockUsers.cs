using System.Text.Json;
using antifragile.Data.Interfaces;
using antifragile.Data.Models;

namespace antifragile.Data.Mocks;

public class MockUsers : IUser
{
    public IEnumerable<User> AllUsers
    {
        get
        {
            using (FileStream fs = new FileStream(
                       @"C:\Users\Владислава\RiderProjects\antifragile\antifragile\Data\Users.json",
                       FileMode.OpenOrCreate))
            {
                List<User> users = JsonSerializer.Deserialize<List<User>>(fs);
                return users;
            }
        }
    }
}