namespace Dar.CodeAnalysis.Syntax
{
    public sealed class BinaryExpressionSyntax : ExpressionSyntax
{
    public override SyntaxKind Kind => SyntaxKind.BinaryExpression;
    public ExpressionSyntax Left {get;}
    public SyntaxToken OperatorToken {get;}
    public ExpressionSyntax Right {get;}
    public BinaryExpressionSyntax(ExpressionSyntax left, SyntaxToken operatorToken, ExpressionSyntax right)
    {
        this.Left = left;
        this.OperatorToken = operatorToken;
        this.Right = right;
    }
 
}
}