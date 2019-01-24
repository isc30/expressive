using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Expressive.QueryProviders;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Expressive
{
    public static class IQueryableExtension
    {
        public static IQueryable<T> Intercept<T>(
            this IQueryable<T> query,
            IReadOnlyCollection<Func<Expression, Expression>> visitors)
        {
            var provider = query.Provider;

            provider = provider is IAsyncQueryProvider asyncProvider
                ? (IQueryProvider)new AsyncInterceptingProvider(asyncProvider, visitors)
                : (IQueryProvider)new InterceptingProvider(provider, visitors);

            return provider.CreateQuery<T>(query.Expression);
        }
    }
}
