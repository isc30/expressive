using System.Linq.Expressions;
using Expressive.InlineCall.ExpressionVisitors;

namespace Expressive.InlineCall
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
