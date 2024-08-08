namespace Dar.CodeAnalysis.Syntax
{
    public sealed class ExpressionStatementSyntax : StatementSyntax
    {
        // a = 10; => GOOD!
        // a + 1 => BAD!
        // M() => GOOD! 
        public ExpressionStatementSyntax(ExpressionSyntax expression)
        {
            Expression = expression;
        }
        public override SyntaxKind Kind => SyntaxKind.ExpressionStatement;
        public ExpressionSyntax Expression { get; }

        
    }

}