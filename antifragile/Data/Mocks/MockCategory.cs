using antifragile.Data.Interfaces;
using antifragile.Models;

namespace antifragile.Data.Mocks;

public class MockCategory : ICategory
{
    public IEnumerable<Category> AllCategories
    {
        get
        {
            return new List<Category>()
            {
                new Category() {CategoryName = "album"},
                new Category() {CategoryName = "pack"},
                new Category() {CategoryName = "box"},
                new Category() {CategoryName = "cards"},
                new Category() {CategoryName = "lightstick"},
                new Category() {CategoryName = "clothes"}
            };
        }
    }
}