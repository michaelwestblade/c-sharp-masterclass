namespace Cookbook;

public class RecipesConsoleUserInteraction: IRecipesUserInteraction
{
    private readonly IngredientsRegistry _ingredientsRegistry;

    public RecipesConsoleUserInteraction(IngredientsRegistry ingredientsRegistry)
    {
        _ingredientsRegistry = ingredientsRegistry;
    }

    public void PrintExistingRecipes(IEnumerable<Recipe> allRecipes)
    {
        if (allRecipes.Count() > 0)
        {
            Console.WriteLine($"Existing recipes are: {Environment.NewLine}");

            var counter = 1;
            foreach (var recipe in allRecipes)
            {
                Console.WriteLine($"*****{counter}*****");
                Console.WriteLine(recipe);
                Console.WriteLine();
                ++counter;
            }
        }
    }

    public void PromptToCreateRecipe()
    {
        Console.WriteLine("Create a new cookie recipe. Here are the available ingredients: ");
        foreach (var ingredient in _ingredientsRegistry.All)
        {
            Console.WriteLine(ingredient);
        }
    }

    public IEnumerable<Ingredient> ReadIngredientsFromUser()
    {
        return new List<Ingredient>()
        {
            new Butter()
        };
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