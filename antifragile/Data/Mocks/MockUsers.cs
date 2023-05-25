using System.Text.Json;
using antifragile.Data.Interfaces;
using antifragile.Data.Models;

namespace antifragile.Data.Mocks;

public class MockUsers : IUser
{
    private static IEnumerable<User> allUsers;

    public void RewriteJson()
    {
        using (FileStream fs = new FileStream(
                   @"C:\Users\Владислава\RiderProjects\antifragile\antifragile\Data\Users.json",
                   FileMode.OpenOrCreate))
        {
            var str = JsonSerializer.Serialize(allUsers, JsonSerializerOptions.Default);
        }
    }
    
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
        set
        {
            allUsers = value;
            RewriteJson();
        }
        
    }
}