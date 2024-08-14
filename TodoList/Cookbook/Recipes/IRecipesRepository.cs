namespace Cookbook;

public interface IRecipesRepository
{
    List<Recipe> Read(string filePath);

    public void Write(string filePath, List<Recipe> allRecipes);
}