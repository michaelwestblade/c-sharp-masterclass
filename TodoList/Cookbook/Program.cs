// See https://aka.ms/new-console-template for more information

using Cookbook;

var cookieRecipesApp = new CookiesRecipesApp(new RecipesRepository(), new RecipesConsoleUserInteraction());

cookieRecipesApp.Run("recipes.txt");