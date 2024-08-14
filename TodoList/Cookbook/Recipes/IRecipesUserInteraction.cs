namespace Cookbook;

public interface IRecipesUserInteraction
{
    void ShowMessage(string message);
    void Exit();
    void PromptToCreateRecipe();
    void PrintExistingRecipes(IEnumerable<Recipe> allRecipes);
    IEnumerable<Ingredient> ReadIngredientsFromUser();
}