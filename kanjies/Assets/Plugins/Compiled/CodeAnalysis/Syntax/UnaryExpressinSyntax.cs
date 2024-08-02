using System;
using System.Collections.Generic;
using System.Linq;


namespace Dar.CodeAnalysis.Syntax
{
    public sealed class UnaryExpressionSyntax : ExpressionSyntax
{
    public override SyntaxKind Kind 
    {
        get
        {
            return SyntaxKind.UnaryExpression;
        }
    }
    public SyntaxToken OperatorToken {get;}
    public ExpressionSyntax Operand { get;}
    public UnaryExpressionSyntax(SyntaxToken operatorToken, ExpressionSyntax operand)
    {
        this.OperatorToken = operatorToken;
        this.Operand = operand;
    }

}
}