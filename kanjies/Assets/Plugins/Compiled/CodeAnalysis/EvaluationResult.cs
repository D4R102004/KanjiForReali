

using System.Collections.Generic;

namespace Dar.CodeAnalysis
{
    public sealed class EvaluationResult
    {
        public EvaluationResult(List<Diagnostic> diagnostics, object value)
        {
            Diagnostics = diagnostics;
            Value = value;
        }

        public List<Diagnostic> Diagnostics { get; }
        public object Value { get; }
    }
}

/*namespace Dar.CodeAnalysis
{
    public sealed class EvaluationResult
    {
        public EvaluationResult(ImmutableArray<Diagnostic> diagnostics, object value)
        {
            Diagnostics = diagnostics;
            Value = value;
        }

        public ImmutableArray<Diagnostic> Diagnostics { get; }
        public object Value { get; }
    }
}*/