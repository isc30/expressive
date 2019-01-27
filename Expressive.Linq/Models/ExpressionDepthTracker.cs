using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Expressive.Linq.Models
{
    public class ExpressionDepthTracker
    {
        public class TrackingNode : IDisposable
        {
            private readonly ExpressionDepthTracker _tracker;

            public TrackingNode(
                ExpressionDepthTracker tracker,
                Expression parent)
            {
                _tracker = tracker;

                _tracker.Increment(parent);
            }

            public void Dispose()
            {
                _tracker.Decrement();
            }
        }

        public Expression CurrentParent => _expressionStack.Peek();

        private readonly Stack<Expression> _expressionStack = new Stack<Expression>();

        public int CurrentDepth => _expressionStack.Count;

        public TrackingNode NewDepth(Expression parent) => new TrackingNode(this, parent);

        protected void Increment(Expression parent)
        {
            _expressionStack.Push(parent);
        }

        protected void Decrement()
        {
            _expressionStack.Pop();
        }
    }
}
