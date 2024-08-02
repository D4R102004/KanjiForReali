namespace Dar.CodeAnalysis.Syntax
{
    public enum SyntaxKind 
    {
        // Tokens
        BadToken,
        EndOfFileToken,
        WhiteSpaceToken,
        NumberToken,
        StringToken,
        PlusToken, 
        MinusToken, 
        StarToken, 
        SlashToken, 
        BangToken,
        EqualsToken,
        TildeToken,
        HatToken,
        AmpersandToken,
        AmpersandAmpersandToken,
        PipeToken,
        PipePipeToken,
        EqualsEqualsToken,
        BangEqualsToken,
        LessToken,
        GreaterToken,
        LessOrEqualsToken,
        GreaterOrEqualsToken,
        OpenParenthesisToken, 
        CloseParenthesisToken, 
        OpenBraceToken,
        CloseBraceToken,
        IdentifierToken,
        
        //Keywords
        ElseKeyword,
        FalseKeyword,
        ForKeyword,
        IfKeyword,
        ToKeyword,
        TrueKeyword,
        LetKeyword,
        VarKeyword,
        WhileKeyword,

        // Nodes
        CompilationUnit,
        ElseClause,

        // Statements
        BlockStatement,
        VariableDeclaration,
        IfStatement,
        WhileStatement,
        ForStatement,
        ExpressionStatement,

        

        // Expressions
        LiteralExpression,
        NameExpression,
        UnaryExpression,
        BinaryExpression, 
        ParenthesizedExpression,
        AssignmentExpression,
        
    }
    
}