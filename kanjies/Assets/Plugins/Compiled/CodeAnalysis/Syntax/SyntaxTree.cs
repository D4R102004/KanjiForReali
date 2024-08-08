
using System.Diagnostics;
using Dar.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using System.Threading;


namespace Dar.CodeAnalysis.Syntax
{
    public sealed class SyntaxTree
    {
        private SyntaxTree(SourceText text)
        {
            var parser = new Parser(text);
            var root = parser.ParseCompilationUnit();
            this.Root = root;
            Text = text;
            this.Diagnostics = parser.Diagnostics.ToList(); // Changed to List<Diagnostic>
        }

        public SourceText Text { get; }
        public List<Diagnostic> Diagnostics { get; } // Changed from ImmutableArray<Diagnostic> to List<Diagnostic>
        public CompilationUnitSyntax Root { get; }

        public static SyntaxTree Parse(string text)
        {
            var sourceText = SourceText.From(text);
            return Parse(sourceText);
        }

        public static SyntaxTree Parse(SourceText text)
        {
            return new SyntaxTree(text);
        }

        public static List<SyntaxToken> ParseTokens(string text) // Changed return type to List<SyntaxToken>
        {
            var sourceText = SourceText.From(text);
            return ParseTokens(sourceText);
        }

        public static List<SyntaxToken> ParseTokens(string text, out List<Diagnostic> diagnostics) // Changed return type and out parameter to List
        {
            var sourceText = SourceText.From(text);
            return ParseTokens(sourceText, out diagnostics);
        }

        public static List<SyntaxToken> ParseTokens(SourceText text)
        {
            return ParseTokens(text); // Assuming ParseTokens has been adjusted to not require an out parameter
        }
        /*public static List<SyntaxToken> ParseTokens(SourceText text) // Changed return type to List<SyntaxToken>
        {
            return ParseTokens(text, out _);
        }*/

        public static List<SyntaxToken> ParseTokens(SourceText text, out List<Diagnostic> diagnostics) // Changed return type and out parameter to List
        {
            var l = new Lexer(text);
            var result = LexTokens(l).ToList(); // Changed to List<SyntaxToken>
            diagnostics = l.Diagnostics.Diagnostics; // Assuming Lexer.Diagnostics is already a List<Diagnostic>
            return result;
        }

        public static IEnumerable<SyntaxToken> LexTokens(Lexer lexer)
        {
            while (true)
            {
                var token = lexer.Lex();
                if (token.Kind == SyntaxKind.EndOfFileToken)
                    break;

                yield return token;
            }
        }
    }
}

/*namespace Dar.CodeAnalysis.Syntax
{
public sealed class SyntaxTree
{
    private SyntaxTree(SourceText text)
    {
        var parser = new Parser(text);
        var root = parser.ParseCompilationUnit();
        this.Root = root;
        Text = text;
        this.Diagnostics = parser.Diagnostics.ToImmutableArray();
    }

    public SourceText Text { get; }
    public ImmutableArray<Diagnostic> Diagnostics {get;}
    public CompilationUnitSyntax Root {get;}
    public static SyntaxTree Parse(string text)
    {
        var sourceText = SourceText.From(text);
        return Parse(sourceText);
    }
    public static SyntaxTree Parse(SourceText text)
    {
        return new SyntaxTree(text);

    }
    public static ImmutableArray<SyntaxToken> ParseTokens(string text)
    {
        var sourceText = SourceText.From(text);
        return ParseTokens(sourceText);
    }

    public static ImmutableArray<SyntaxToken> ParseTokens(string text, out ImmutableArray<Diagnostic> diagnostics )
    {
        var sourceText = SourceText.From(text);
        return ParseTokens(sourceText, out diagnostics);
    }
    public static ImmutableArray<SyntaxToken> ParseTokens(SourceText text)
    {
        return ParseTokens(text, out _);
    }

    public static ImmutableArray<SyntaxToken> ParseTokens(SourceText text, out ImmutableArray<Diagnostic> diagnostics)
    {
        
        var l = new Lexer(text);
        var result = LexTokens(l).ToImmutableArray();
        diagnostics = l.Diagnostics.ToImmutableArray();
        return result;
    }
    public static IEnumerable<SyntaxToken> LexTokens(Lexer lexer)
        {
            while (true)
            {
                var token = lexer.Lex();
                if (token.Kind == SyntaxKind.EndOfFileToken) 
                    break;
                    
                yield return token;
            }
        }
}
    
}*/