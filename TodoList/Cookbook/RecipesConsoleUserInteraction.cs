namespace Cookbook;

public class RecipesConsoleUserInteraction: IRecipesUserInteraction
{
    public void PrintExistingRecipes(object allRecipes)
    {
        throw new NotImplementedException();
    }

    public void PromptToCreateRecipe()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Ingredient> ReadIngredientsFromUser()
    {
        throw new NotImplementedException();
    }

    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }

    public void Exit()
    {
        Console.WriteLine("Press any key to close.");
        Console.ReadKey();
    }
}