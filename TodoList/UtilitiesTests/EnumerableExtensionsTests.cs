using NUnit.Framework;
using Utilities;

namespace UtilitiesTests;

[TestFixture]
public class EnumerableExtensionsTests
{
    [Test]
    // MethodName_ExpectedBehavior_Scenario
    // OR MethodName_Scenario_ExpectedBehavior
    public void SumOfEvenNumbers_ShallReturnZero_ForEmptyCollection()
    {
        var input = Enumerable.Empty<int>();

        var result = input.SumOfEvenNumbers();
        
        Assert.AreEqual(0, result);
    }
    
    [Test]
    public void SumOfEvenNumbers_ShallReturnExpectedValue_ForValidCollection()
    {
        var input = new int[] { 3, 1, 4, 6, 7 };

        var result = input.SumOfEvenNumbers();
        
        Assert.AreEqual(10, result);
    }
    
    [Test]
    public void SumOfEvenNumbers_ShallReturnValueOfTheOnlyItem_IfItIsEven()
    {
        var input = new int[] { 2 };

        var result = input.SumOfEvenNumbers();
        
        Assert.AreEqual(2, result);
    }
    
    [Test]
    public void SumOfEvenNumbers_ShallReturnZero_IfNoneAreEven()
    {
        var input = new int[] { 3,5,7,9 };

        var result = input.SumOfEvenNumbers();
        
        Assert.AreEqual(0, result);
    }
}