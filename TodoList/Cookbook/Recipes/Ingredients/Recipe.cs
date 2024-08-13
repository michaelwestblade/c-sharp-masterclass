namespace Cookbook;

public class Recipe
{
    public IEnumerable<Ingredient> Ingredients { get; }

    public Recipe(List<Ingredient> ingredients)
    {
        Ingredients = ingredients;
    }
}