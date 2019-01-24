using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Expressive.InlineCall.ExpressionVisitors
{
    public sealed class LambdaParameterReplacer : ExpressionVisitor
    {
        public static LambdaExpression Replace(
            LambdaExpression expression,
            IReadOnlyDictionary<ParameterExpression, Expression> replacements)
        {
            return (LambdaExpression)new LambdaParameterReplacer(replacements).Visit(expression);
        }

        private readonly IReadOnlyDictionary<ParameterExpression, Expression> _replacements;

        private LambdaParameterReplacer(
            IReadOnlyDictionary<ParameterExpression, Expression> replacements)
        {
            _replacements = replacements;
        }

        protected override Expression VisitLambda<TDelegate>(Expression<TDelegate> node)
        {
            var parameters = node.Parameters.Where(p => !_replacements.ContainsKey(p));
            var body = Visit(node.Body) ?? Expression.Empty();

            return Expression.Lambda(body, parameters);
        }

        protected override Expression VisitParameter(
            ParameterExpression node)
        {
            return _replacements.ContainsKey(node)
                ? _replacements[node]
                : base.VisitParameter(node);
        }
    }
}
