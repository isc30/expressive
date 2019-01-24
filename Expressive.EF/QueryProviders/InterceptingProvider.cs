using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Expressive.QueryProviders
{
    internal class InterceptingProvider : IQueryProvider
    {
        protected readonly IQueryProvider UnderlyingProvider;
        protected readonly IReadOnlyCollection<Func<Expression, Expression>> Visitors;

        public InterceptingProvider(
            IQueryProvider underlyingProvider,
            IReadOnlyCollection<Func<Expression, Expression>> visitors)
        {
            UnderlyingProvider = underlyingProvider;
            Visitors = visitors;
        }

        public IQueryable<TElement> CreateNativeQuery<TElement>(Expression expression)
        {
            return UnderlyingProvider.CreateQuery<TElement>(Intercept(expression));
        }

        public IQueryable CreateNativeQuery(Expression expression)
        {
            return UnderlyingProvider.CreateQuery(Intercept(expression));
        }

        protected Expression Intercept(Expression expression)
        {
            foreach (var visitor in Visitors)
            {
                expression = visitor(expression);
            }

            return expression;
        }

        public IQueryable CreateQuery(Expression expression)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            return new InterceptingQuery<TElement>(this, expression);
        }

        public object Execute(Expression expression)
        {
            return UnderlyingProvider.Execute(Intercept(expression));
        }

        public TResult Execute<TResult>(Expression expression)
        {
            return UnderlyingProvider.Execute<TResult>(Intercept(expression));
        }
    }
}
