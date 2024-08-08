using System.Reflection;
using System;
using System.Xml;
using Dar.CodeAnalysis.Text;

using System.Collections.Generic;
using System.IO;
using System.Linq;

using System.Threading;


namespace Dar.CodeAnalysis.Syntax
{
public abstract class SyntaxNode
{
    public abstract SyntaxKind Kind {get;}
    public virtual TextSpan Span
    {
        get
        {
            var first = GetChildren().First().Span;
            var last = GetChildren().Last().Span;
            return TextSpan.FromBounds(first.Start, last.End);
        }
    }
    public IEnumerable<SyntaxNode> GetChildren()
    {
        var properties = GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
        foreach (var property in properties)
        {
            if (typeof(SyntaxNode).IsAssignableFrom(property.PropertyType))
            {
                var child = (SyntaxNode)property.GetValue(this);
                if (child != null)
                    yield return child;
            }
            else if (typeof(IEnumerable<SyntaxNode>).IsAssignableFrom(property.PropertyType))
            {
                var children = (IEnumerable<SyntaxNode>)property.GetValue(this);
                foreach (var child in children)
                {
                    if (child != null)
                        yield return child;
                }
            }
        }
    }
    public SyntaxToken GetLastToken()
    {
        if (this is SyntaxToken) 
        {
            var token = (SyntaxToken)this;
            return token;
        }
        return GetChildren().Last().GetLastToken();
        
    }
/*    public void WriteTo(TextWriter writer)
    {
        PrettyPrint(writer, this);
    }*/
/*    private static void PrettyPrint(TextWriter writer, SyntaxNode node, string indent = "", bool isLast = true)
    {
        // └──
        // ├──
        // │
        var isToConsole = writer == Console.Out;

        var marker = isLast ? "└──" : "├──";
        
        writer.Write(indent);

        if (isToConsole)
            Console.ForegroundColor = ConsoleColor.DarkGray;

        writer.Write(marker);
        

        if (isToConsole)
            Console.ForegroundColor = node is SyntaxToken ? ConsoleColor.Blue : ConsoleColor.Cyan;
        
        writer.Write(node.Kind);
        if (node is SyntaxToken)
        {
            var t = (SyntaxToken)node;
            if  (t.Value != null)
            {
                System.Console.Write(" ");
                Console.Write(t.Value);
            }
        }

        if (isToConsole)
            Console.ResetColor();
        
        writer.WriteLine();
        indent += isLast ? "   " : "│   ";
        var lastChild = node.GetChildren().LastOrDefault();
        foreach (var child in node.GetChildren()) 
            PrettyPrint(writer, child, indent, child == lastChild);
    }*/

        public override string ToString()
        {
            using (var writer = new StringWriter())
            {
//                WriteTo(writer);

                return writer.ToString();
            }
        }

    }
}