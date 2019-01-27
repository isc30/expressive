using Expressive;
using Expressive.Linq.ExpressionVisitors;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Linq
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Wow()
        {
            var expr = Expr.New((int n) => n + 8 * n);
            var descendants = ExpressionDepthVisitor.Descendants(expr);
        }
    }
}
