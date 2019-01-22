using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Expressive.ExpressionVisitors
{
    public sealed class CallExtensionInliner : ExpressionVisitor
    {
        public static Expression Inline<TExpr>(Expression expression)
            where TExpr : Expression
        {
            return (TExpr)new CallExtensionInliner().Visit(expression);
        }

        private CallExtensionInliner()
        {
        }

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

            var expressionCallMethod = typeof(ExpressionCallExtension).GetMethods()
                .Where(m => m.Name == nameof(ExpressionCallExtension.Call))
                .FirstOrDefault(m => m == invokedMethod);

            if (expressionCallMethod == null)
            {
                return null;
            }

            var lambdaToInline = ExtractLambdaExpression(Visit(node.Arguments.First()));
            var arguments = node.Arguments.Skip(1).Select(Visit).ToList();
            var replacements = GetReplacements(lambdaToInline.Parameters, arguments);
            var replacedLambda = LambdaParameterReplacer.Replace(lambdaToInline, replacements);

            return Visit(replacedLambda.Body);
        }

        private static LambdaExpression ExtractLambdaExpression(Expression thisExpression)
        {
            return (LambdaExpression)Expression
                .Lambda<Func<object>>(Expression.Convert(thisExpression, typeof(object)))
                .Compile()();
        }

        private static IReadOnlyDictionary<ParameterExpression, Expression> GetReplacements(
            IReadOnlyList<ParameterExpression> parameters,
            IReadOnlyList<Expression> arguments)
        {
            return parameters
                .Select((p, i) => new { Key = p, Value = arguments[i] })
                .ToDictionary(p => p.Key, p => p.Value);
        }
    }
}
