using System.Linq.Expressions;

namespace Expressive.UnitTests.Helpers
{
    public static class ExpressionAssert
    {
        public static bool ExpressionEquals(LambdaExpression left, LambdaExpression right)
        {
            if (left.GetType() != right.GetType()
                || left.Type != right.Type
                || left.ReturnType != right.ReturnType
                || left.Parameters.Count != right.Parameters.Count
                || left.ToString() != right.ToString())
            {
                return false;
            }

            for (var i = 0; i < left.Parameters.Count; i++)
            {
                var leftParameter = left.Parameters[i];
                var rightParameter = right.Parameters[i];

                if (!ParameterEquals(leftParameter, rightParameter))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool ParameterEquals(ParameterExpression left, ParameterExpression right)
        {
            return
                left.GetType() == right.GetType()
                && left.IsByRef == right.IsByRef
                && left.CanReduce == right.CanReduce
                && left.Name == right.Name
                && left.NodeType == right.NodeType
                && left.Type == right.Type;
        }
    }
}
