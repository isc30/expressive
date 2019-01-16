using System;
using System.Linq.Expressions;
using Expressive.UnitTests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Expressive.UnitTests.Tests.Extensions
{
    [TestClass]
    public class ExpressionCallExtensionTest
    {
        [TestMethod]
        [DataRow(11)]
        [DataRow(222)]
        [DataRow(3333)]
        public void Memory_0Args(int n)
        {
            var expr = Expr.New(() => n);

            Assert.AreEqual(n, expr.Call());
        }

        [TestMethod]
        [DataRow(-999, 10, true)]
        [DataRow(9, 10, true)]
        [DataRow(10, 10, false)]
        [DataRow(999, 10, false)]
        public void Memory_1Args(int n, int max, bool expected)
        {
            var comparer = Expr.New((int x) => x < max);

            Assert.AreEqual(comparer.Call(n), expected);
        }

        [TestMethod]
        [DataRow(-999, 5, 10, false)]
        [DataRow(4, 5, 10, false)]
        [DataRow(5, 5, 10, true)]
        [DataRow(10, 5, 10, true)]
        [DataRow(11, 5, 10, false)]
        public void Memory_NestedCalls(int n, int min, int max, bool expected)
        {
            var comparerMin = Expr.New((int x) => x >= min);
            var comparerMax = Expr.New((int x) => x <= max);
            var comparer = Expr.New((int x) => comparerMin.Call(x) && comparerMax.Call(x));

            Assert.AreEqual(expected, comparer.Call(n));
        }

        [TestMethod]
        public void Expanded_Call()
        {
            var predicate = Expr.New((int n, int d) => n < d);

            Assert.IsTrue(ExpressionAssert.ExpressionEquals(
               Expr.New((int n) => n < 22),
               Expr.New((int n) => predicate.Call(n, 22)).Expand()));
        }

        [TestMethod]
        public void Expanded_NestedCalls()
        {
            Expression<Func<int, int, bool>> predicate = (n, d) => n < d;
            Expression<Func<int, int, bool>> predicate2 = (n, d) => (n == d || predicate.Call(n, d));

            Assert.IsTrue(ExpressionAssert.ExpressionEquals(
                (Expression<Func<int, bool>>)(n => n == 45 || n < 45),
                Expr.New((int n) => predicate2.Call(n, 45)).Expand()));
        }
    }
}
