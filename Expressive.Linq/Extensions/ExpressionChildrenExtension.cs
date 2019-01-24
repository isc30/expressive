using System.Collections.Generic;
using System.Linq.Expressions;

namespace Expressive.Linq
{
    public static class ExpressionChildrenExtension
    {
        /// <summary>
        /// All nodes directly connected to this parent
        /// </summary>
        public static IEnumerable<Expression> Children(this UnaryExpression parent)
        {
            yield return parent.Operand;
        }

        /// <summary>
        /// All nodes directly connected to this parent
        /// </summary>
        public static IEnumerable<Expression> Children(this BinaryExpression parent)
        {
            yield return parent.Left;
            yield return parent.Right;
        }

        /// <summary>
        /// All nodes directly connected to this parent
        /// </summary>
        public static IEnumerable<Expression> Children(this MemberExpression parent)
        {
            yield return parent.Expression;
        }

        /// <summary>
        /// All nodes directly connected to this parent
        /// </summary>
        public static IEnumerable<Expression> Children(this LambdaExpression parent)
        {
            foreach (var parameter in parent.Parameters)
            {
                yield return parameter;
            }

            yield return parent.Body;
        }

        /// <summary>
        /// All nodes directly connected to this parent
        /// </summary>
        public static IEnumerable<Expression> Children(this Expression parent)
        {
            if (parent is UnaryExpression unary)
            {
                return unary.Children();
            }

            if (parent is BinaryExpression binary)
            {
                return binary.Children();
            }

            if (parent is MemberExpression member)
            {
                return member.Children();
            }

            if (parent is LambdaExpression lambda)
            {
                return lambda.Children();
            }

            return new Expression[0];
        }
    }
}
