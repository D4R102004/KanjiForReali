using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Dar.CodeAnalysis.Symbols;

namespace Dar.CodeAnalysis.Binding
{
    internal abstract class BoundExpression : BoundNode
    {
        public abstract TypeSymbol Type{get; }
    }
}
