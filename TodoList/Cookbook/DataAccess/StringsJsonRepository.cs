using System.Text.Json;

namespace Cookbook;

public class StringsJsonRepository: StringsRepository
{
    protected override List<string> TextToStrings(string fileContents)
    {
        return JsonSerializer.Deserialize<List<string>>(fileContents);
    }

    protected override string StringsToText(List<string> strings)
    {
        return JsonSerializer.Serialize(strings);
    }
}