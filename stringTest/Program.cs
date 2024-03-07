using System.Diagnostics;

namespace stringTest
{
    static internal class Program
    {
        static void Main(string[] args)
        {
            var testCount = 100000000;

            var stringOneCased = "Hello, World!";
            var stringTwoLower = "hello, world!";
            var stringTwoUpper = "HELLO, WORLD!";

            DoTest("ToLowerInvariant", testCount, stringOneCased, stringTwoLower, ToLowerInvariantTest);

            DoTest("ToUpperInvariant", testCount, stringOneCased, stringTwoUpper, ToUpperInvariantTest);

            DoTest("DOUBLE ToLowerInvariant", testCount, stringOneCased, stringTwoUpper, ToLowerInvariantDoubleTest);

            DoTest("Equals (NoOptions)", testCount, stringOneCased, stringOneCased, StringEqualsNoOptionsTest);

            DoTest("Equals (InvariantCultureIgnoreCase)", testCount, stringOneCased, stringTwoLower, StringEqualsInvariantCultureIgnoreCaseTest);

            DoTest("Equals (CurrentCultureIgnoreCase)", testCount, stringOneCased, stringTwoLower, StringEqualsCurrentCultureIgnoreCaseCaseTest);

            DoTest("Equals (OrdinalIgnoreCase)", testCount, stringOneCased, stringTwoLower, StringEqualsOrdinalIgnoreCaseCaseTest);
        }

        static void DoTest(string testName, int testCount, string left, string right, Func<string,string,bool> compare)
        {
            var stopwatch = new Stopwatch();
            var count = 0;

            Console.WriteLine($"Testing: {testName} {testCount} times");
            Console.WriteLine("==================");

            stopwatch.Reset();
            stopwatch.Start();
            for (int i = 0; i < testCount; i++)
            {
                if (compare(left, right))
                {
                    count++;
                }
            }
            stopwatch.Stop();

            Console.WriteLine($"Time elapsed (ms): {stopwatch.Elapsed.TotalMilliseconds} ({testName})");
            Console.WriteLine();
            Console.WriteLine();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1862:Use the 'StringComparison' method overloads to perform case-insensitive string comparisons", Justification = "Test Case")]
        static bool ToLowerInvariantTest(string left, string right)
        {
            return left.ToLowerInvariant() == right;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1862:Use the 'StringComparison' method overloads to perform case-insensitive string comparisons", Justification = "Test Case")]
        static bool ToUpperInvariantTest(string left, string right)
        {
            return left.ToUpperInvariant() == right;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1862:Use the 'StringComparison' method overloads to perform case-insensitive string comparisons", Justification = "Test Case")]
        static bool ToLowerInvariantDoubleTest(string left, string right)
        {
            return left.ToLowerInvariant() == right.ToLowerInvariant();
        }

        static bool StringEqualsNoOptionsTest(string left, string right)
        {
            return left.Equals(right);
        }

        static bool StringEqualsInvariantCultureIgnoreCaseTest(string left, string right)
        {
            return left.Equals(right, StringComparison.InvariantCultureIgnoreCase);
        }

        static bool StringEqualsCurrentCultureIgnoreCaseCaseTest(string left, string right)
        {
            return left.Equals(right, StringComparison.CurrentCultureIgnoreCase);
        }

        static bool StringEqualsOrdinalIgnoreCaseCaseTest(string left, string right)
        {
            return left.Equals(right, StringComparison.OrdinalIgnoreCase);
        }
    }
}
