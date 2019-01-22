using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Expressive.UnitTests.Core.Tests.Extensions
{
    [TestClass]
    public class ExpressionToFuncExtensionTest
    {
        [TestMethod]
        [DataRow(11)]
        [DataRow(222)]
        [DataRow(3333)]
        public void ToFunc_0Args(int n)
        {
            var expr = Expr.New(() => n);
            var compiled = expr.ToFunc();

            Assert.AreEqual(n, compiled());
        }

        [TestMethod]
        [DataRow(-999, 10, true)]
        [DataRow(9, 10, true)]
        [DataRow(10, 10, false)]
        [DataRow(999, 10, false)]
        public void ToFunc_1Args(int n, int max, bool expected)
        {
            var comparer = Expr.New((int x) => x < max);
            var compiled = comparer.ToFunc();

            Assert.AreEqual(expected, compiled(n));
        }
    }
}
