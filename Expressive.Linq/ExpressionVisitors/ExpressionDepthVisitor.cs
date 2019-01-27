using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using Expressive.Linq.Models;

namespace Expressive.Linq.ExpressionVisitors
{
    public class ExpressionDepthVisitor : ExpressionVisitor
    {
        public static IDictionary<int, List<Expression>> Descendants(Expression expression)
        {
            var visitor = new ExpressionDepthVisitor();
            var result = visitor.Visit(expression);

            return visitor.ExtractedDescendants;
        }

        protected bool _excludeFirst = true;
        protected ExpressionDepthTracker _depthTracker = new ExpressionDepthTracker();
        protected Dictionary<int, List<Expression>> ExtractedDescendants = new Dictionary<int, List<Expression>>();

        private void AddNode(Expression node)
        {
            if (_excludeFirst)
            {
                _excludeFirst = false;
                return;
            }

            if (!ExtractedDescendants.ContainsKey(_depthTracker.CurrentDepth))
            {
                ExtractedDescendants[_depthTracker.CurrentDepth] = new List<Expression>();
            }

            ExtractedDescendants[_depthTracker.CurrentDepth].Add(node);
        }

        public override Expression Visit(Expression node)
        {
            AddNode(node);

            return base.Visit(node);
        }

        protected override Expression VisitBinary(BinaryExpression node)
        {
            using (_depthTracker.NewDepth(node))
            {
                return base.VisitBinary(node);
            }
        }

        protected override Expression VisitBlock(BlockExpression node)
        {
            using (_depthTracker.NewDepth(node))
            {
                return base.VisitBlock(node);
            }
        }

        protected override Expression VisitConditional(ConditionalExpression node)
        {
            using (_depthTracker.NewDepth(node))
            {
                return base.VisitConditional(node);
            }
        }
    }
}
