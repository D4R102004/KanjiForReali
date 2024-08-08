using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections.Immutable;

namespace Dar.CodeAnalysis.Binding
{
    internal sealed class BoundBlockStatement : BoundStatement
    {
        public BoundBlockStatement(ImmutableArray<BoundStatement> statements) 
        {
            Statements = statements;
        }
        public override BoundNodeKind Kind => BoundNodeKind.BlockStatement;
        public ImmutableArray<BoundStatement> Statements { get; }
    }
}