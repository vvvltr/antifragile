using System.Text.Json.Serialization;
using antifragile.Data.Interfaces;
using antifragile.Data.Models;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace antifragile.Data.Mocks;

public class MockUsers : IUser
{
    private string Pathstr = @"C:\Users\Владислава\RiderProjects\antifragile\antifragile\Data\Users.json";

    public IEnumerable<User> AllUsers
    {
        get
        { 
            string json = File.ReadAllText(Pathstr);
            List<User> users = JsonConvert.DeserializeObject<List<User>>(json);
            return users;
            /*
            using (FileStream fs = new FileStream(Pathstr, FileMode.Open))
            {
                //List<User> users = JsonSerializer.Deserialize<List<User>>(fs);
                var users = JsonConvert.DeserializeObject<List<User>>(Pathstr);
                return users;
            }*/
        }
    }

    public void AddUser(User newUser)
    {
        List<User> currUsers = new List<User>(AllUsers);
        currUsers.Add(newUser);

        string serializeUsers = JsonConvert.SerializeObject(currUsers);
        File.WriteAllText(Pathstr, serializeUsers);
    }

    public List<User> ReadAllUsers()
    {
        string json = File.ReadAllText(Pathstr);
        List<User> users = JsonConvert.DeserializeObject<List<User>>(json);
        return users;
    }
}