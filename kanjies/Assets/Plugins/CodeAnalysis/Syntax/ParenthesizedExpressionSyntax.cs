namespace Dar.CodeAnalysis.Syntax
{
public sealed class ParenthesizedExpressionSyntax : ExpressionSyntax
{
    public override SyntaxKind Kind => SyntaxKind.ParenthesizedExpression;
    public SyntaxToken OpenParenthesisToken {get;}
    public ExpressionSyntax Expression{get;}
    public SyntaxToken CloseParenthesisToken {get;}
    public ParenthesizedExpressionSyntax(SyntaxToken openParenthesisToken, ExpressionSyntax expression, SyntaxToken closeParenthesistoken)
    {
        this.OpenParenthesisToken = openParenthesisToken;
        this.Expression = expression;
        this.CloseParenthesisToken = closeParenthesistoken;
    }
}
    
}