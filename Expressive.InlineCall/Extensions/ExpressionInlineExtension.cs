using System.Linq.Expressions;
using Expressive.ExpressionVisitors;

namespace Expressive
{
    public static class ExpressionInlineExtension
    {
        public static TExpr Inline<TExpr>(this TExpr expression)
            where TExpr : Expression
        {
            return (TExpr)CallExtensionInliner.Inline<TExpr>(expression);
        }
    }
}
