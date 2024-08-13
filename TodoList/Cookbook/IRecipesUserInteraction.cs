namespace Cookbook;

public interface IRecipesUserInteraction
{
    void ShowMessage(string message);
    void Exit();
    void PromptToCreateRecipe();
    void PrintExistingRecipes(object allRecipes);
    IEnumerable<Ingredient> ReadIngredientsFromUser();
}