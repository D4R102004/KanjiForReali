using Dar.CodeAnalysis.Symbols;

namespace Dar.CodeAnalysis.Binding
{
    internal sealed class BoundVariableDeclaration : BoundStatement
    {
        public BoundVariableDeclaration(VariableSymbol variable, BoundExpression initializer)
        {
            Variable = variable;
            Initializer = initializer;
        }

        public override BoundNodeKind Kind 
        {
            get
            {
                return BoundNodeKind.VariableDeclaration;
            }
        }

        public VariableSymbol Variable { get; }
        public BoundExpression Initializer { get; }
    }
}