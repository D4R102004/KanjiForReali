using Dar.CodeAnalysis.Symbols;

namespace Dar.CodeAnalysis.Binding
{
    internal sealed class BoundBinaryExpression : BoundExpression
    {
        public override TypeSymbol Type 
        {
            get
            {
                return Op.ResultType;
            }
        }
        public override BoundNodeKind Kind 
        {
            get
            {
                return BoundNodeKind.BinaryExpression;
            }
        }
        public BoundBinaryOperator Op { get;}
        public BoundExpression Left { get; }
        public BoundExpression Right { get; }
        public BoundBinaryExpression(BoundExpression left, BoundBinaryOperator op, BoundExpression right)
        {
            Left = left;
            Right = right;
            Op = op;
        }        
    }
}