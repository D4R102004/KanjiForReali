


using System.Collections.Generic;

namespace Dar.CodeAnalysis.Syntax
{
    public sealed class BlockStatementSyntax : StatementSyntax
    {
        public BlockStatementSyntax(SyntaxToken openBraceToken,
                           List<StatementSyntax> statements, // Changed from ImmutableArray<StatementSyntax> to List<StatementSyntax>
                           SyntaxToken closeBraceToken)
        {
            OpenBraceToken = openBraceToken;
            Statements = statements;
            CloseBraceToken = closeBraceToken;
        }

        public override SyntaxKind Kind 
        {
            get
            {
                return SyntaxKind.BlockStatement;
            }
        }

        public SyntaxToken OpenBraceToken { get; }
        public List<StatementSyntax> Statements { get; } // Changed from ImmutableArray<StatementSyntax> to List<StatementSyntax>
        public SyntaxToken CloseBraceToken { get; }    
    }
}
/*namespace Dar.CodeAnalysis.Syntax
{
    public sealed class BlockStatementSyntax : StatementSyntax
    {
        public BlockStatementSyntax(SyntaxToken openBraceToken,
                                    ImmutableArray<StatementSyntax> statements,
                                    SyntaxToken closeBraceToken)
        {
            OpenBraceToken = openBraceToken;
            Statements = statements;
            CloseBraceToken = closeBraceToken;
        }

        public override SyntaxKind Kind 
        {
            get
            {
                return SyntaxKind.BlockStatement;
            }
        }

        public SyntaxToken OpenBraceToken { get; }
        public ImmutableArray<StatementSyntax> Statements { get; }
        public SyntaxToken CloseBraceToken { get; }    
    }
}*/