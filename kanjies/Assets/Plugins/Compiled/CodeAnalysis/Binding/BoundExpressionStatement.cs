
namespace Dar.CodeAnalysis.Binding
{
    internal sealed class BoundExpressionStatement : BoundStatement
    {
        public BoundExpressionStatement(BoundExpression expression) 
        {
            Expression = expression;
        }
        public override BoundNodeKind Kind 
        {
            get
            {
                return BoundNodeKind.ExpressionStatement;
            }
        }

        public BoundExpression Expression { get; }
    }
}