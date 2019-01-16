using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Expressive.ExpressionVisitors
{
    public class ParameterReplacer : ExpressionVisitor
    {
        public static LambdaExpression Replace(
            LambdaExpression expression,
            IDictionary<ParameterExpression, Expression> replacements)
        {
            return (LambdaExpression)new ParameterReplacer(replacements).Visit(expression);
        }

        private readonly IDictionary<ParameterExpression, Expression> _replacements;

        public ParameterReplacer(
            IDictionary<ParameterExpression, Expression> replacements)
        {
            _replacements = replacements;
        }

        protected override Expression VisitLambda<T>(
            Expression<T> node)
        {
            var parameters =
                node.Parameters.Where(
                    p => !_replacements.ContainsKey(p) || !(_replacements[p] is ConstantExpression));

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
