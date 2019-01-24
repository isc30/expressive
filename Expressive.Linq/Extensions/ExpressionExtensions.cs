using System.Linq;
using System.Linq.Expressions;

namespace Expressive.Linq
{
    public static class ExpressionExtensions
    {
        /// <summary>
        /// Node with at least one child
        /// </summary>
        public static bool IsBranch(this Expression node)
        {
            return node.Children().Any();
        }

        /// <summary>
        /// Node with no children
        /// </summary>
        public static bool IsLeaf(this Expression node)
        {
            return !node.Children().Any();
        }
    }
}
