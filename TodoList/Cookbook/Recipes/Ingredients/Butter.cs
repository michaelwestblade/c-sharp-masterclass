namespace Cookbook;

public class Butter : Ingredient
{
    public override int Id => 3;
    public override string Name => "Spelt Flour";
    public override string PreparationInstructions => $"Melt on low heat. {base.PreparationInstructions}";
}