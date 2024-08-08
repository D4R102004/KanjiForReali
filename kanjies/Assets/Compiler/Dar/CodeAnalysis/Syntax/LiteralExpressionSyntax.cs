using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

namespace Dar.CodeAnalysis.Syntax
{
    public sealed class LiteralExpressionSyntax : ExpressionSyntax
    {
        public override SyntaxKind Kind => SyntaxKind.LiteralExpression;
        public SyntaxToken LiteralToken {get;}
        public object Value { get; }
        public LiteralExpressionSyntax(SyntaxToken literalToken) :
        this(literalToken, literalToken.Value)
        {
        }
            public LiteralExpressionSyntax(SyntaxToken literalToken, object value)
        {
            this.LiteralToken = literalToken;
                Value = value;
        }
    }
    public sealed class PostfixUnaryExpressionSyntax : ExpressionSyntax
    {
        public PostfixUnaryExpressionSyntax(SyntaxToken operand, SyntaxToken)
        {
        }


        public override SyntaxKind Kind => SyntaxKind.PostfixUnaryExpression;

    }
}
