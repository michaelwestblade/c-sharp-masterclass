namespace Cookbook;

public interface IIngredientsRegistry
{
    IEnumerable<Ingredient?> All { get; }
    Ingredient? GetById(int id);
}