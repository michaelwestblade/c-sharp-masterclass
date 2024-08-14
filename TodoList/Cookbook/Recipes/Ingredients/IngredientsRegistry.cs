using System.Collections;

namespace Cookbook;

public class IngredientsRegistry
{

    public IEnumerable<Ingredient> All { get; } = new List<Ingredient>()
    {
        new WheatFlour(),
        new SpeltFlour(),
        new Butter(),
        new Chocolate(),
        new Sugar(),
        new Cardamom(),
        new Cinnamon(),
        new CocoaPowder()
    };
}