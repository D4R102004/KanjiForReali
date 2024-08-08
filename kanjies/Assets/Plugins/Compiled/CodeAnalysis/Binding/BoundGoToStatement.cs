namespace Dar.CodeAnalysis.Binding
{
    internal sealed class BoundGoToStatement : BoundStatement
    {
        public BoundGoToStatement(BoundLabel label)
        {
            Label = label;
        }

        public override BoundNodeKind Kind 
        {
            get
            {
                return BoundNodeKind.GoToStatement;
            }
        }

        public BoundLabel Label { get; }
    }
}