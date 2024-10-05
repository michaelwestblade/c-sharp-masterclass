using System.Collections;
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
    
    [TestCase(8, 8)]
    [TestCase(-8, -8)]
    [TestCase(6, 6)]
    [TestCase(0, 0)]
    public void SumOfEvenNumbers_ShallReturnValueOfTheOnlyItem_IfItIsEven(int number, int expected)
    {
        var input = new int[] { number };

        var result = input.SumOfEvenNumbers();
        
        Assert.AreEqual(expected, result);
    }
    
    [TestCase(1)]
    [TestCase(7)]
    [TestCase(33)]
    public void SumOfEvenNumbers_ShallReturnZero_IfNoneAreEven(int number)
    {
        var input = new int[] { number };

        var result = input.SumOfEvenNumbers();
        
        Assert.AreEqual(0, result);
    }

    [TestCaseSource(nameof(GetSumOfEvenNumbersTestCases))]
    public void SumOfEvenNumbers_ShallReturnNonZeroResult_IfEvenNumbers(int[] input, int expected)
    {
        var result = input.SumOfEvenNumbers();
        
        Assert.AreEqual(expected, result);
    }

    private static IEnumerable GetSumOfEvenNumbersTestCases()
    {
        return new[]
        {
            new object[] { new int[] { 3, 1, 4, 6, 9 }, 10 },
            new object[] { new List<int>() { 100, 200, 1 }, 300 },
        };
    }
}