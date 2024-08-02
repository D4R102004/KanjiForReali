
namespace Dar.CodeAnalysis.Syntax
{
    public sealed class NameExpressionSyntax : ExpressionSyntax
    {
        public NameExpressionSyntax(SyntaxToken identifierToken)
        {
            IdentifierToken = identifierToken;
        }
        public override SyntaxKind Kind 
        {
            get
            {
                return SyntaxKind.NameExpression;
            }
        }
        public SyntaxToken IdentifierToken { get; }


    }
}