namespace Cookbook;

public interface IRecipesRepository
{
    List<Recipe> Read(string filePath);

    public void Write(object filePath, List<Recipe> allRecipes);
}