using Microsoft.VisualBasic;

namespace Cookbook;

public class RecipesRepository: IRecipesRepository
{
    private readonly IStringsRepository _stringsRepository;
    private readonly IIngredientsRegistry _ingredientsRegistry;
    private const string Separator = ",";

    public RecipesRepository(IStringsRepository stringsRepository, IIngredientsRegistry ingredientsRegistry)
    {
        _stringsRepository = stringsRepository;
        _ingredientsRegistry = ingredientsRegistry;
    }

    public List<Recipe> Read(string filePath)
    {
        var recipesFromFile = _stringsRepository.Read(filePath);

        return recipesFromFile.Select(RecipeFromString).ToList();
    }

    private Recipe RecipeFromString(string recipeFromFile)
    {
        var ingredients = recipeFromFile.Split(Separator)
            .Select(int.Parse)
            .Select(_ingredientsRegistry.GetById).ToList();
        
        return new Recipe(ingredients);
    }

    public void Write(string filePath, List<Recipe> allRecipes)
    {
        // var recipesAsStrings = allRecipes
        //     .Select(recipe => string.Join(Separator, recipe.Ingredients.Select(ingredient => ingredient.Id))).ToList();
        var recipesAsStrings = allRecipes.Select(recipe =>
        {
            var allIds = recipe.Ingredients.Select(ingredient => ingredient.Id);
            return string.Join(Separator, allIds);
        }).ToList();
        _stringsRepository.Write(filePath, recipesAsStrings);
    }
}