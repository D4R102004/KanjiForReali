using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dar.CodeAnalysis.Binding
{
    internal sealed class BoundExpressionStatement : BoundStatement
    {
        public BoundExpressionStatement(BoundExpression expression) 
        {
            Expression = expression;
        }
        public override BoundNodeKind Kind => BoundNodeKind.ExpressionStatement;
        public BoundExpression Expression { get; }
    }
}
