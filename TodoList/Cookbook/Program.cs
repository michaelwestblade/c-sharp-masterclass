// See https://aka.ms/new-console-template for more information

using Cookbook;

const FileFormat fileFormat = FileFormat.JSON;
const string fileName = "recipes";
var fileMetaData = new FileMetaData(fileName, fileFormat);
IStringsRepository stringsRepository =
    fileFormat == FileFormat.JSON ? new StringsJsonRepository() : new StringsTextRepository();

var ingredientRegistry = new IngredientsRegistry();
var cookieRecipesApp = new CookiesRecipesApp(new RecipesRepository(stringsRepository, ingredientRegistry), new RecipesConsoleUserInteraction(ingredientRegistry));

cookieRecipesApp.Run(fileMetaData.ToPath());