using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dar.CodeAnalysis.Binding
{
    internal enum BoundUnaryOperatorKind
    {
        Identity, 
        Negation,
        LogicalNegation,
        OnesComplement
    }
}