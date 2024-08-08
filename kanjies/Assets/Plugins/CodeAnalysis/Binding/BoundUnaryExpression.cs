using Dar.CodeAnalysis.Symbols;

namespace Dar.CodeAnalysis.Binding
{
    internal sealed class BoundUnaryExpression : BoundExpression
    {
        public override TypeSymbol Type => Op.Type;
        public override BoundNodeKind Kind => BoundNodeKind.UnaryExpression;
        public BoundUnaryOperator Op { get;}
        public BoundExpression Operand { get; }
        public BoundUnaryExpression(BoundUnaryOperator op, BoundExpression operand)
        {
            this.Operand = operand;
            this.Op = op;
        }        
    }
}