using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Expressive.Linq.Extensions;

namespace Expressive.Linq
{
    public static class ExpressionDescendantsExtension
    {
        /// <summary>
        /// All nodes under this root (recursive children)
        /// </summary>
        public static IEnumerable<Expression> Descendants<T>(this T root)
            where T : Expression
        {
            var children = new Queue<Expression>(root.Children());

            while (children.Any())
            {
                var child = children.Dequeue();

                yield return child;

                children.EnqueueRange(child.Children());
            }
        }
    }
}
