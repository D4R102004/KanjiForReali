using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dar.CodeAnalysis.Binding
{
    internal enum BoundNodeKind 
    {
        // Statements
        BlockStatement,
        VariableDeclaration,
        IfStatement,
        WhileStatement,
        ForStatement,
        LabelStatement,
        GoToStatement,
        ConditionalGoToStatement,
        ExpressionStatement,
        


        // Expressions
        ErrorExpression,
        LiteralExpression,
        VariableExpression,
        AssignmentExpression,
        UnaryExpression,
        BinaryExpression,
        
    }
}
