// See https://aka.ms/new-console-template for more information

using Cookbook;

var ingredientRegistry = new IngredientsRegistry();
var cookieRecipesApp = new CookiesRecipesApp(new RecipesRepository(new StringsJsonRepository(), ingredientRegistry), new RecipesConsoleUserInteraction(ingredientRegistry));

cookieRecipesApp.Run("recipes.json");