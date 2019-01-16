using System.Linq.Expressions;
using Expressive.ExpressionVisitors;

namespace Expressive
{
    public static class ExpressionExpandExtension
    {
        public static Expression<TDelegate> Expand<TDelegate>(this Expression<TDelegate> expression)
        {
            return (Expression<TDelegate>)new ExpressionCallExpander().Visit(expression);
        }

        public static LambdaExpression Expand(this LambdaExpression expression)
        {
            return (LambdaExpression)new ExpressionCallExpander().Visit(expression);
        }

        public static Expression Expand(this Expression expression)
        {
            return new ExpressionCallExpander().Visit(expression);
        }
    }
}
