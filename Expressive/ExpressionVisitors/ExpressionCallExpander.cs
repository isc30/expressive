using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Expressive.ExpressionVisitors
{
    public class ExpressionCallExpander : ExpressionVisitor
    {
        protected override Expression VisitMember(MemberExpression node)
        {
            return base.VisitMember(node);
        }

        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            return VisitExpressionExtensionInvoke(node)
                ?? base.VisitMethodCall(node);
        }

        private Expression VisitExpressionExtensionInvoke(MethodCallExpression node)
        {
            var invokedMethod = node.Method.GetGenericMethodDefinition();

            var callMethod = typeof(ExpressionCallExtension).GetMethods()
                .Where(m => m.Name == nameof(ExpressionCallExtension.Call))
                .SingleOrDefault(m => m == invokedMethod);

            if (callMethod == null)
            {
                return null;
            }

            var lambdaToInline = ExtractLambdaExpression(Visit(node.Arguments.First()));
            var arguments = node.Arguments.Skip(1).Select(Visit).ToArray();
            var replacements = GetReplacements(lambdaToInline.Parameters, arguments);
            var replacedLambda = ParameterReplacer.Replace(lambdaToInline, replacements);

            return Visit(replacedLambda.Body);
        }

        private static LambdaExpression ExtractLambdaExpression(Expression member)
        {
            return (LambdaExpression)Expression
                .Lambda<Func<object>>(Expression.Convert(member, typeof(object)))
                .Compile()();
        }

        private static IDictionary<ParameterExpression, Expression> GetReplacements(
            IEnumerable<ParameterExpression> parameters,
            IReadOnlyList<Expression> arguments)
        {
            return parameters
                .Select((p, i) => new { Key = p, Value = arguments[i] })
                .ToDictionary(p => p.Key, p => p.Value);
        }
    }
}
