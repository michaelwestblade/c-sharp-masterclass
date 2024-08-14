namespace Cookbook;

public class RecipesConsoleUserInteraction: IRecipesUserInteraction
{
    private readonly IIngredientsRegistry _ingredientsRegistry;

    public RecipesConsoleUserInteraction(IIngredientsRegistry ingredientsRegistry)
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
        bool shallStop = false;
        var ingredients = new List<Ingredient>();

        while (!shallStop)
        {
            ShowMessage("Add an ingredient by its ID or type anything else if finished.");
            var userInput = Console.ReadLine();

            if (int.TryParse(userInput, out int id))
            {
                var selectedIngredient = _ingredientsRegistry.GetById(id);
                if (selectedIngredient is not null)
                {
                    ingredients.Add(selectedIngredient);
                }
            }
            else
            {
                shallStop = true;
            }
        }

        return ingredients;
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