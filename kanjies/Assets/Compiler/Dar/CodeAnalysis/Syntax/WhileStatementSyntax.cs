using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dar.CodeAnalysis.Syntax
{
    public sealed class WhileStatementSyntax : StatementSyntax
    {
        public WhileStatementSyntax(SyntaxToken whileKeyword, ExpressionSyntax condition, StatementSyntax body)
        {
            WhileKeyword = whileKeyword;
            Condition = condition;
            Body = body;
        }
        public override SyntaxKind Kind => SyntaxKind.WhileStatement;
        public SyntaxToken WhileKeyword { get; }
        public ExpressionSyntax Condition { get; }
        public StatementSyntax Body { get; }

        
    }
}
