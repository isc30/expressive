using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Expressive.QueryProviders
{
    internal class AsyncInterceptingProvider : InterceptingProvider, IAsyncQueryProvider
    {
        protected IAsyncQueryProvider AsyncUnderlyingProvider;

        public AsyncInterceptingProvider(
            IAsyncQueryProvider underlyingProvider,
            IReadOnlyCollection<Func<Expression, Expression>> visitors)
            : base(underlyingProvider, visitors)
        {
            AsyncUnderlyingProvider = underlyingProvider;
        }

        public IAsyncEnumerable<TResult> ExecuteAsync<TResult>(Expression expression)
        {
            return AsyncUnderlyingProvider.ExecuteAsync<TResult>(Intercept(expression));
        }

        public Task<TResult> ExecuteAsync<TResult>(Expression expression, CancellationToken cancellationToken)
        {
            return AsyncUnderlyingProvider.ExecuteAsync<TResult>(Intercept(expression), cancellationToken);
        }
    }
}
