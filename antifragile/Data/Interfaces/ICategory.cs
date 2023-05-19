using antifragile.Models;

namespace antifragile.Data.Interfaces;

public interface ICategory
{
    IEnumerable<Category> AllCategories { get; }
}