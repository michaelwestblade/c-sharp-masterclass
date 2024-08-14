// See https://aka.ms/new-console-template for more information

using Cookbook;

var ingredientRegistry = new IngredientsRegistry();
var cookieRecipesApp = new CookiesRecipesApp(new RecipesRepository(new StringsRepository(), ingredientRegistry), new RecipesConsoleUserInteraction(ingredientRegistry));

cookieRecipesApp.Run("recipes.txt");