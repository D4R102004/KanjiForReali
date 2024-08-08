

using System.Collections.Generic;

namespace Dar.CodeAnalysis.Binding
{
    internal sealed class BoundBlockStatement : BoundStatement
    {
        private readonly List<BoundStatement> _statements;

        public BoundBlockStatement(List<BoundStatement> statements)
        {
            _statements = statements;
        }

        public override BoundNodeKind Kind
        {
            get
            {
                return BoundNodeKind.BlockStatement;
            }
        }

        public List<BoundStatement> Statements 
        {
            get
            {
                return _statements;
            }
        }
    }
}
/*namespace Dar.CodeAnalysis.Binding
{
    internal sealed class BoundBlockStatement : BoundStatement
    {
        public BoundBlockStatement(ImmutableArray<BoundStatement> statements) 
        {
            Statements = statements;
        }
        public override BoundNodeKind Kind 
        {
            get
            {
                return BoundNodeKind.BlockStatement;
            }
        }
        public ImmutableArray<BoundStatement> Statements { get; }
    }
}*/