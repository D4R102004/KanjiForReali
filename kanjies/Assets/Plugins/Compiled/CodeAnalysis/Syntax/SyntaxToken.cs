
using Dar.CodeAnalysis.Text;

namespace Dar.CodeAnalysis.Syntax
{
public sealed class SyntaxToken : SyntaxNode
{
    public override SyntaxKind Kind {get;}
    public int Position {get;}
    public string Text {get;}
    public object Value {get;}
    public override TextSpan Span
    {
        get
        {
            int l;
            if (Text == null)
                l = 0;
            else
                l = Text.Length;   
            return new TextSpan(Position, l);
        }
    }

    public bool IsMissing 
    {
        get
        {
            return Text == null;
        }
    }
    public SyntaxToken(SyntaxKind kind, int position, string text, object value)
    {
        this.Kind = kind;
        this.Position = position;
        this.Text = text;
        this.Value = value;
    }
}
}