


using System.Collections.Generic;
using Dar.CodeAnalysis.Symbols;

namespace Dar.CodeAnalysis.Binding
{
    internal sealed class BoundGlobalScope
    {
        public BoundGlobalScope(BoundGlobalScope previous, List<Diagnostic> diagnostics,
                          List<VariableSymbol> variables, BoundStatement statement)
        {
            Previous = previous;
            Diagnostics = diagnostics;
            Variables = variables;
            Statement = statement;
        }

        public BoundGlobalScope Previous { get; }
        public List<Diagnostic> Diagnostics { get; } // Changed from ImmutableArray<Diagnostic> to List<Diagnostic>
        public List<VariableSymbol> Variables { get; } // Changed from ImmutableArray<VariableSymbol> to List<VariableSymbol>
        public BoundStatement Statement { get; }

}
/*namespace Dar.CodeAnalysis.Binding
{
    internal sealed class BoundGlobalScope
    {
        public BoundGlobalScope(BoundGlobalScope previous, ImmutableArray<Diagnostic> diagnostics,
                                ImmutableArray<VariableSymbol> variables, BoundStatement statement)
        {
            Previous = previous;
            Diagnostics = diagnostics;
            Variables = variables;
            Statement = statement;
        }

        public BoundGlobalScope Previous { get; }
        public ImmutableArray<Diagnostic> Diagnostics { get; }
        public ImmutableArray<VariableSymbol> Variables { get; }
        public BoundStatement Statement { get; }
    }
}*/
}