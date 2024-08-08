using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dar.CodeAnalysis.Syntax
{
    public sealed class UnaryExpressionSyntax : ExpressionSyntax
{
    public override SyntaxKind Kind => SyntaxKind.UnaryExpression;
    public SyntaxToken OperatorToken {get;}
    public ExpressionSyntax Operand { get;}
    public UnaryExpressionSyntax(SyntaxToken operatorToken, ExpressionSyntax operand)
    {
        this.OperatorToken = operatorToken;
        this.Operand = operand;
    }

}
}