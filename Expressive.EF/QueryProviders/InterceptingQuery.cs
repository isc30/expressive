using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Expressive.QueryProviders
{
    internal class InterceptingQuery<T> : IOrderedQueryable<T>, IAsyncEnumerable<T>
    {
        private readonly InterceptingProvider _provider;

        public InterceptingQuery(
            InterceptingProvider provider,
            Expression expression)
        {
            _provider = provider;
            Expression = expression;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _provider.CreateNativeQuery<T>(Expression).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        IAsyncEnumerator<T> IAsyncEnumerable<T>.GetEnumerator()
        {
            var query = _provider.CreateNativeQuery<T>(Expression);

            if (query is IAsyncEnumerable<T> asyncQuery)
            {
                return asyncQuery.GetEnumerator();
            }

            throw new InvalidOperationException("Unable to perform async queries on mocks");
        }

        public Type ElementType => typeof(T);

        public Expression Expression { get; }

        public IQueryProvider Provider => _provider;

        /*public virtual InterceptedQuery<T> Include(string path)
        {
            var expression = _provider.UnderlyingProvider.CreateQuery<T>(_expression).Include(path).Expression;

            return new InterceptedQuery<T>(_provider, expression);
        }

        public virtual IQueryable<T> AsNoTracking()
        {
            var expression = _provider.UnderlyingProvider.CreateQuery(_expression).AsNoTracking().Expression;

            return new InterceptedQuery<T>(_provider, expression);
        }*/
    }
}
