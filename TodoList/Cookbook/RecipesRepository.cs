namespace Cookbook;

public class RecipesRepository: IRecipesRepository
{
    public List<Recipe> Read(string filePath)
    {
        return new List<Recipe>()
        {
            new Recipe(new List<Ingredient>()
            {
                new WheatFlour(),
                new Butter(),
                new Sugar()
            }),
            new Recipe(new List<Ingredient>()
            {
                new CocoaPowder(),
                new SpeltFlour(),
                new Cinnamon()
            })
        };
    }

    public void Write(object filePath, List<Recipe> allRecipes)
    {
        Console.WriteLine("");
    }
}