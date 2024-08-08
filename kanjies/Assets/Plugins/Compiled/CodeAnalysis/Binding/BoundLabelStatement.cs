namespace Dar.CodeAnalysis.Binding
{
    internal sealed class BoundLabelStatement : BoundStatement
    {
        public BoundLabelStatement(BoundLabel label)
        {
            Label = label;
        }
        public override BoundNodeKind Kind
        {
            get
            {
                return BoundNodeKind.LabelStatement;
            }
        }

        public BoundLabel Label { get; }

        
    }
}