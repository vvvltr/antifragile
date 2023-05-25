using System.Text.Json;
using antifragile.Data.Interfaces;
using antifragile.Data.Models;

namespace antifragile.Data.Mocks;

public class MockUsers : IUser
{
    private static IEnumerable<User> allUsers = new List<User>()
    {
        new User() {id = 0, Name = "vltr", Email = "vltr@ya.ru", Password = "123", PhoneNumber = "72919100"}
    };

    public IEnumerable<User> AllUsers
    {
        get { return allUsers; }
        /*using (FileStream fs = new FileStream(
                   @"C:\Users\Владислава\RiderProjects\antifragile\antifragile\Data\Users.json",
                   FileMode.OpenOrCreate))
        {
            List<User> users = JsonSerializer.Deserialize<List<User>>(fs);
            return users;
        }*/
        
        set
        {
            allUsers = value;
        }
    }
    
}