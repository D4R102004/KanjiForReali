using System.Collections.Immutable;
using Dar.CodeAnalysis.Symbols;

namespace Dar.CodeAnalysis.Binding
{
    internal sealed class BoundScope
    {
        private Dictionary<string, VariableSymbol> _variables = new Dictionary<string, VariableSymbol>();
        public BoundScope(BoundScope parent)
        {
            Parent = parent;
        }
        public BoundScope Parent { get; }
        public bool TryDeclare(VariableSymbol variable)
        {
            // var x = 10
            // {
            //      var x = false => GOOD;
            // } 
            // var x = 10 => BAD
            if (_variables.ContainsKey(variable.Name))
                return false;

            _variables.Add(variable.Name, variable);
            return true;
        }
        public bool TryLookUp(string name, out VariableSymbol variable)
        {
            if (_variables.TryGetValue(name, out variable))
                return true;
            return Parent == null ? false : Parent.TryLookUp(name, out variable);
        }
        public ImmutableArray<VariableSymbol> GetDeclaredVariables()
        {
            return _variables.Values.ToImmutableArray();
        }
    }
}