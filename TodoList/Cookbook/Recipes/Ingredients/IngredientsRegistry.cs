using System.Collections;

namespace Cookbook;

public class IngredientsRegistry : IIngredientsRegistry
{

    public IEnumerable<Ingredient?> All { get; } = new List<Ingredient?>()
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

    public Ingredient? GetById(int id)
    {
        var allIngredientsWithGivenId = All.Where(i => i.Id == id);
        
        if (allIngredientsWithGivenId.Count() > 1)
        {
            throw new InvalidOperationException($"More than one ingredient with id {id} was found.");
        }

        return allIngredientsWithGivenId.FirstOrDefault();
    }
}