using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dar.CodeAnalysis.Binding
{
    internal sealed class BoundLabelStatement : BoundStatement
    {
        public BoundLabelStatement(BoundLabel label)
        {
            Label = label;
        }
        public override BoundNodeKind Kind => BoundNodeKind.LabelStatement;

        public BoundLabel Label { get; }

        
    }
}
