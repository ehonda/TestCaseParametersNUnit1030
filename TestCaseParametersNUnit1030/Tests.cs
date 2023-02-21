using NUnit.Framework.Internal;

namespace TestCaseParametersNUnit1030;

// Uncomment to demonstrate false positive
// #pragma warning disable NUnit1030

public class Tests
{
    private static class TestCases
    {
        public static IEnumerable<TestCaseParameters> All => new[]
        {
            new TestCaseData(1), new TestCaseData(2)
        };
    }

    [TestCaseSource(typeof(TestCases), nameof(TestCases.All))]
    public void Test(int n)
    {
        Assert.That(n, Is.GreaterThan(0));
    }
}
