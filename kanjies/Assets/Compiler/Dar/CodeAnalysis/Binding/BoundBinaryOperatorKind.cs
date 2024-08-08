using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dar.CodeAnalysis.Binding
{
    internal enum BoundBinaryOperatorKind
    {
        Addition,
        Substraction,
        Multiplication,
        Division,
        LogicalAnd,
        LogicalOr,
        BitwiseAnd,
        BitwiseOr,
        BitwiseXor,
        Equals,
        NotEquals,
        Less,
        LessOrEquals,
        Greater,
        GreaterOrEquals,
        
    }
}
