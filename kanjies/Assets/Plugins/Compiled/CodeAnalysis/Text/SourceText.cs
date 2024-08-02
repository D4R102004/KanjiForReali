
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using System.Threading;



namespace Dar.CodeAnalysis.Text
{
    public sealed class SourceText
    {
        private readonly string _text;
        private List<TextLine> _lines; // Changed from ImmutableArray<TextLine> to List<TextLine>

        private SourceText(string text)
        {
            _text = text;
            _lines = ParseLines(this, text);
        }

        public List<TextLine> Lines 
        {
            get
            {
                return _lines; // Expose as IReadOnlyList to simulate immutability
            }
        }

        public char this[int index]
        {
            get
            {
                return _text[index];
            }
        }

        public int Length
        {
            get
            {
                return _text.Length;
            }
        }

        public int GetLineIndex(int position)
        {
            var lower = 0;
            var upper = _lines.Count - 1; // Adjusted for List

            while (lower <= upper)
            {
                var index = lower + (upper - lower) / 2;
                var start = _lines[index].Start;

                if (position == start)
                {
                    return index;
                }

                if (start > position)
                {
                    upper = index - 1;
                }
                else
                {
                    lower = index + 1;
                }
            }

            return lower - 1;
        }

        private static List<TextLine> ParseLines(SourceText sourceText, string text)
        {
            var result = new List<TextLine>();

            var position = 0;
            var lineStart = 0;

            while (position < text.Length)
            {
                var lineBreakWidth = GetLineBreakWidth(text, position);
                
                if (lineBreakWidth == 0)
                {
                    position++;
                }
                else
                {
                    AddLine(result, sourceText, position, lineStart, lineBreakWidth);
                    position += lineBreakWidth;
                    lineStart = position;
                }
            }
            if (position >= lineStart)
            {
                AddLine(result, sourceText, position, lineStart, 0);
            }
            return result;
        }

        private static void AddLine(List<TextLine> result, SourceText sourceText, int position, int lineStart, int lineBreakWidth)
        {
            var lineLength = position - lineStart;
            var lineLengthIncludingLineBreak = lineLength + lineBreakWidth;
            var line = new TextLine(sourceText, lineStart, lineLength, lineLengthIncludingLineBreak);
            result.Add(line);
        }

        private static int GetLineBreakWidth(string text, int position)
        {
            var c = text[position];
            var l = position + 1 >= text.Length ? '\0' : text[position + 1];

            if (c == '\r' && l == '\n')
                return 2;

            if (c == '\r' || c == '\n')
                return 1;

            return 0;
        }

        public static SourceText From(string text)
        {
            return new SourceText(text);
        }
        public override string ToString()
        {
            return _text;
        }
        public string ToString(int start, int length)
        {
            return _text.Substring(start, length);
        }
        public string ToString(TextSpan span)
        {
            return ToString(span.Start, span.Length);
        }

        // Constructor and other methods remain unchanged
    }
}
    /*public sealed class SourceText
    {
        private readonly string _text;

        private SourceText(string text)
        {
            _text = text;
            Lines = ParseLines(this, text);
        }

        public ImmutableArray<TextLine> Lines { get; private set; }

        public char this[int index] 
        {
            get
            {
                return _text[index];
            }
        }
        public int Length 
        {
            get
            {
                return _text.Length;
            }
        }

        public int GetLineIndex(int position)
        {
            var lower = 0;
            var upper = Lines.Length - 1;

            while (lower <= upper)
            {
                var index = lower + (upper - lower) / 2;
                var start = Lines[index].Start;

                if (position == start)
                {
                    return index;
                }

                if (start > position)
                {
                    upper = index - 1;
                }
                else
                {
                    lower = index + 1;
                }
            }

            return lower - 1;

        }

        private static List<TextLine> ParseLines(SourceText sourceText, string text)
        {
            var result = new List<TextLine>(); // Changed from ImmutableArray.CreateBuilder<TextLine>() to List<TextLine>

            var position = 0;
            var lineStart = 0;

            while (position < text.Length)
            {
                var lineBreakWidth = GetLineBreakWidth(text, position);
                
                if (lineBreakWidth == 0)
                {
                    position++;
                }
                else
                {
                    AddLine(result, sourceText, position, lineStart, lineBreakWidth);
                    position += lineBreakWidth;
                    lineStart = position;
                }
            }
            if (position >= lineStart)
            {
                AddLine(result, sourceText, position, lineStart, 0);
            }
            return result; // Directly return the List<TextLine>, no need to convert with ToImmutable()
        }

        private static void AddLine(List<TextLine> result, SourceText sourceText, int position, int lineStart, int lineBreakWidth)
        {
            var lineLength = position - lineStart;
            var lineLengthIncludingLineBreak = lineLength + lineBreakWidth;
            var line = new TextLine(sourceText, lineStart, lineLength, lineLengthIncludingLineBreak);
            result.Add(line); // Directly add to the List<TextLine>
        }

        /*private static ImmutableArray<TextLine> ParseLines(SourceText sourceText, string text)
        {
            var result = ImmutableArray.CreateBuilder<TextLine>();

            var position = 0;

            var lineStart = 0;

            while (position < text.Length)
            {
                var lineBreakWidth = GetLineBreakWidth(text, position);
                
                if (lineBreakWidth == 0)
                {
                    position++;
                }
                else
                {
                    AddLine(result, sourceText, position, lineStart, lineBreakWidth);
                    position += lineBreakWidth;
                    lineStart = position;
                }
            }
            if (position >= lineStart)
            {
                AddLine(result, sourceText, position, lineStart, 0);
            }
            return result.ToImmutable();
        }

        private static void AddLine(ImmutableArray<TextLine>.Builder result, SourceText sourceText, int position, int lineStart, int lineBreakWidth)
        {
            var lineLength = position - lineStart;
            var lineLengthIncludingLineBreak = lineLength + lineBreakWidth;
            var line = new TextLine(sourceText, lineStart, lineLength, lineLengthIncludingLineBreak);
            result.Add(line);
        }

        private static int GetLineBreakWidth(string text, int position)
        {
            var c = text[position];
            var l = position + 1 >= text.Length ? '\0' : text[position + 1];

            if (c == '\r' && l == '\n')
                return 2;

            if (c == '\r' || c == '\n')
                return 1;

            return 0;

        }

        public static SourceText From(string text)
        {
            return new SourceText(text);
        }
        public override string ToString() 
        {
            return _text;
        }
        public string ToString(int start, int length) 
        {
            return _text.Substring(start, length);
        }
        public string ToString(TextSpan span)
        {
            return ToString(span.Start, span.Length);
        }

    } */

