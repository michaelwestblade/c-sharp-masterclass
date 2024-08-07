namespace Names_SRP;

public class NamesFormatter
{
    private static readonly string Separator = Environment.NewLine;
    public string Format(List<string> names)
    {
        return string.Join(Separator, names);
    }
}