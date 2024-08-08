using Dar.CodeAnalysis.Symbols;

namespace Dar.CodeAnalysis.Binding
{
    internal sealed class BoundErrorExpression : BoundExpression
    {
        public override BoundNodeKind Kind 
        {
            get
            {
                return BoundNodeKind.ErrorExpression;
            }
        }
        public override TypeSymbol Type 
        {
            get
            {
                return TypeSymbol.Error;
            }
        }
        
    }
}