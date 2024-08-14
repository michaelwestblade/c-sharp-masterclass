using Microsoft.VisualBasic;

namespace Cookbook;

public class RecipesRepository: IRecipesRepository
{
    private readonly StringsRepository _stringsRepository;
    private readonly IIngredientsRegistry _ingredientsRegistry;
    private const string Separator = ",";

    public RecipesRepository(StringsRepository stringsRepository, IIngredientsRegistry ingredientsRegistry)
    {
        _stringsRepository = stringsRepository;
        _ingredientsRegistry = ingredientsRegistry;
    }

    public List<Recipe> Read(string filePath)
    {
        var recipesFromFile = _stringsRepository.Read(filePath);

        var recipes = new List<Recipe>();
        foreach (var recipeFromFile in recipesFromFile)
        {
            var recipe = RecipeFromString(recipeFromFile);
            recipes.Add(recipe);
        }

        return recipes;
    }

    private Recipe RecipeFromString(string recipeFromFile)
    {
        var textIds = recipeFromFile.Split(Separator);
        var ingredients = new List<Ingredient>();

        foreach (var textId in textIds)
        {
            var id = int.Parse(textId);
            var ingredient = _ingredientsRegistry.GetById(id);
            ingredients.Add(ingredient);
        }
        
        return new Recipe(ingredients);
    }

    public void Write(string filePath, List<Recipe> allRecipes)
    {
        var recipesAsStrings = new List<string>();
        foreach (var recipe in allRecipes)
        {
            var allIds = new List<int>();
            foreach (var ingredient in recipe.Ingredients)
            {
                allIds.Add(ingredient.Id);
            }
            recipesAsStrings.Add(string.Join(Separator, allIds));
        }
        
        _stringsRepository.Write(filePath, recipesAsStrings);
    }
}