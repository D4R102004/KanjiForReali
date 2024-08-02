

using Dar.CodeAnalysis.Symbols;
using Dar.CodeAnalysis.Syntax;

namespace Dar.CodeAnalysis.Binding
{
    internal sealed class Binder
    {
        private readonly DiagnosticBag _diagnostics = new DiagnosticBag();
        private BoundScope _scope;

        public Binder(BoundScope parent)
        {
            _scope = new BoundScope(parent);
        }

        public static BoundGlobalScope BindGlobalScope(BoundGlobalScope previous, CompilationUnitSyntax syntax)
        {
            var parentScope = CreateParentScope(previous);
            var binder = new Binder(parentScope);
            var expression = binder.BindStatement(syntax.Statement);
            var variables = binder._scope.GetDeclaredVariables();
            var diagnostics = binder.Diagnostics.ToImmutableArray();

            if (previous != null)
                diagnostics = diagnostics.InsertRange(0, previous.Diagnostics);
            
            return new BoundGlobalScope(previous, diagnostics, variables, expression);
        }

        private static BoundScope CreateParentScope(BoundGlobalScope previous)
        {
            // submission 3 -> submission 2 -> submission 1
            //
            var stack = new Stack<BoundGlobalScope>();
            while (previous != null)
            {
                stack.Push(previous);
                previous = previous.Previous;
            }

            BoundScope parent = null;

            while (stack.Count > 0)
            {
                previous = stack.Pop();
                var scope = new BoundScope(parent);
                foreach (var v in previous.Variables)
                    scope.TryDeclare(v);
                
                parent = scope;
            }

            return parent;
        }


        public DiagnosticBag Diagnostics 
        {
            get
            {
                return _diagnostics;
            }
        }

        private BoundStatement BindStatement(StatementSyntax syntax)
        {

            /*return syntax.Kind switch 
            {
                SyntaxKind.BlockStatement => BindBlockStatement(syntax as BlockStatementSyntax),
            };*/


            switch (syntax.Kind)
            {
                case SyntaxKind.BlockStatement:
                    return BindBlockStatement((BlockStatementSyntax)syntax);
                
                case SyntaxKind.VariableDeclaration:
                    return BindVariableDeclaration((VariableDeclarationSyntax)syntax);

                case SyntaxKind.IfStatement:
                    return BindIfStatement((IfStatementSyntax)syntax);

                case SyntaxKind.WhileStatement:
                    return BindWhileStatement((WhileStatementSyntax)syntax);

                case SyntaxKind.ForStatement:
                    return BindForStatement((ForStatementSyntax)syntax);

                case SyntaxKind.ExpressionStatement:
                    return BindExpressionStatement((ExpressionStatementSyntax)syntax);
                
                default: 
                    throw new Exception("Unexpected syntax '" + syntax.Kind + "'.");
            }
        }

        

        private BoundStatement BindBlockStatement(BlockStatementSyntax syntax)
        {
            var statements = ImmutableArray.CreateBuilder<BoundStatement>();
            _scope = new BoundScope(_scope);

            foreach (var statementSyntax in syntax.Statements)
            {
                var statement = BindStatement(statementSyntax);
                statements.Add(statement);
            }
            _scope = _scope.Parent;
            return new BoundBlockStatement(statements.ToImmutable());
        }

        private BoundStatement BindVariableDeclaration(VariableDeclarationSyntax syntax)
        {
            var isReadOnly = syntax.Keyword.Kind == SyntaxKind.LetKeyword;
            var initializer = BindExpression(syntax.Initializer);
            var variable = BindVariable(syntax.Identifier, isReadOnly, initializer.Type);
            return new BoundVariableDeclaration(variable, initializer);
        }

        private BoundStatement BindIfStatement(IfStatementSyntax syntax)
        {
            var condition = BindExpression(syntax.Condition, TypeSymbol.Bool);
            var thenStatement = BindStatement(syntax.ThenStatement);
            var elseStatement = syntax.ElseClause == null ?
                                null : BindStatement(syntax.ElseClause.ElseStatement);
            return new BoundIfStatement(condition, thenStatement, elseStatement);
        }

        private BoundStatement BindWhileStatement(WhileStatementSyntax syntax)
        {
            var condition = BindExpression(syntax.Condition, TypeSymbol.Bool);
            var body = BindStatement(syntax.Body);
            return new BoundWhileStatement(condition, body);
        }

        private BoundStatement BindForStatement(ForStatementSyntax syntax)
        {
            var lowerBound = BindExpression(syntax.LowerBound, TypeSymbol.Int);
            var upperBound = BindExpression(syntax.UpperBound, TypeSymbol.Int);
            _scope = new BoundScope(_scope);

            VariableSymbol variable = BindVariable(syntax.Identifier, true, TypeSymbol.Int);
            //VariableSymbol variable = BindVariable(syntax.Identifier, IsReadOnly : true, TypeSymbol.Int);

            var body = BindStatement(syntax.Body);

            _scope = _scope.Parent;
            return new BoundForStatement(variable, lowerBound, upperBound, body);
        }

      

        private BoundStatement BindExpressionStatement(ExpressionStatementSyntax syntax)
        {
            var expression = BindExpression(syntax.Expression);
            return new BoundExpressionStatement(expression);
        }

        private BoundExpression BindExpression(ExpressionSyntax syntax, TypeSymbol targetType)
        {
            var result = BindExpression(syntax);
            if (targetType != TypeSymbol.Error && 
                result.Type != TypeSymbol.Error &&
                result.Type != targetType)
            {
                _diagnostics.ReportCannotConvert(syntax.Span, result.Type, targetType);
            }
            return result;
        }

        private BoundExpression BindExpression(ExpressionSyntax syntax)
        {
            switch (syntax.Kind)
            {
                case SyntaxKind.ParenthesizedExpression:
                    return BindParenthesizedExpression((ParenthesizedExpressionSyntax)syntax);

                case SyntaxKind.LiteralExpression:
                    return BindLiteralExpression((LiteralExpressionSyntax)syntax);

                case SyntaxKind.NameExpression:
                    return BindNameExpression((NameExpressionSyntax)syntax);

                case SyntaxKind.AssignmentExpression:
                    return BindAssignmentExpression((AssignmentExpressionSyntax)syntax);

                case SyntaxKind.BinaryExpression:
                    return BindBinaryExpression((BinaryExpressionSyntax)syntax);

                case SyntaxKind.UnaryExpression:
                    return BindUnaryExpression((UnaryExpressionSyntax)syntax);
                
                default: throw new Exception("Unexpected syntax '" + syntax.Kind + "'");
            }
        }
        private BoundExpression BindParenthesizedExpression(ParenthesizedExpressionSyntax syntax)
        {
            return BindExpression(syntax.Expression);
        }

        private BoundExpression BindLiteralExpression(LiteralExpressionSyntax syntax)
        { 
            var value = syntax.Value ?? 0;
            return new BoundLiteralExpression(value);
        }

        private BoundExpression BindNameExpression(NameExpressionSyntax syntax)
        {
            var name = syntax.IdentifierToken.Text;

            if (syntax.IdentifierToken.IsMissing)
            {
                // This means the token was insertedby the parser.
                // We already declared an error, so we return error expression.
                return new BoundErrorExpression();
            }
            
            // Manually check if the variable exists in the scope
            bool variableFound = false;
            foreach (var existingVariable in _scope.Variables)
            {
                if (existingVariable.Name == name)
                {
                    variableFound = true;
                    break; // Exit the loop once the variable is found
                }
            }

            // If the variable was not found, report the error
            if (!variableFound)
            {
                _diagnostics.ReportUndefinedName(syntax.IdentifierToken.Span, name);
                // Return a BoundErrorExpression to indicate an error occurred
                return new BoundErrorExpression();
            }

            // If the variable was found, proceed to create and return a BoundVariableExpression
            return new BoundVariableExpression(existingVariable);
            /*if (!_scope.TryLookUp(name, out var variable))
            {
                _diagnostics.ReportUndefinedName(syntax.IdentifierToken.Span, name);
                return new BoundErrorExpression();
            }
            return new BoundVariableExpression(variable);*/
        }

        // a = b = c
        private BoundExpression BindAssignmentExpression(AssignmentExpressionSyntax syntax)
        {
            var name = syntax.IdentifierToken.Text;
            var boundExpression = BindExpression(syntax.Expression);

            foreach (var existingVariable in _scope.Variables)
            {
                if (existingVariable.Name == name)
                {
                    // Variable found, no action needed beyond this point
                    break;
                }
            }

        // If the loop completes without finding the variable, report the error
        if (!_scope.Variables.Any(var => var.Name == name))
        {
            _diagnostics.ReportUndefinedName(syntax.IdentifierToken.Span, name);
            // Return boundExpression or handle the undefined variable as needed
            return boundExpression;
        }
            /*if (!_scope.TryLookUp(name, out var variable))
            {
                _diagnostics.ReportUndefinedName(syntax.IdentifierToken.Span, name);
                return boundExpression;
            }*/

            if (variable.IsReadOnly)
            {
                _diagnostics.ReportCannotAssign(syntax.EqualsToken.Span, name);
            }

            if (boundExpression.Type != variable.Type)
            {
                _diagnostics.ReportCannotConvert(syntax.Expression.Span, boundExpression.Type, variable.Type);
                return boundExpression;
            }

            return new BoundAssignmentExpression(variable, boundExpression);
        }

        private BoundExpression BindUnaryExpression(UnaryExpressionSyntax syntax)
        {
            var boundOperand = BindExpression(syntax.Operand);

            if (boundOperand.Type == TypeSymbol.Error)
                return new BoundErrorExpression();

            var boundOperator = BoundUnaryOperator.Bind(syntax.OperatorToken.Kind, boundOperand.Type);
            if (boundOperator == null) 
            {
                _diagnostics.ReportUndefinedUnaryOperator(syntax.OperatorToken.Span, syntax.OperatorToken.Text, boundOperand.Type);
                return new BoundErrorExpression();
            }
            return new BoundUnaryExpression(boundOperator, boundOperand);
        }
        private BoundExpression BindBinaryExpression(BinaryExpressionSyntax syntax)
        {
            var boundLeft = BindExpression(syntax.Left);
            var boundRight = BindExpression(syntax.Right);

            if (boundLeft.Type == TypeSymbol.Error || boundRight.Type == TypeSymbol.Error)
                return new BoundErrorExpression();
            
            var boundOperator = BoundBinaryOperator.Bind(syntax.OperatorToken.Kind, boundLeft.Type, boundRight.Type);
            if (boundOperator == null) 
            {
                _diagnostics.ReportUndefinedBinaryOperator(syntax.OperatorToken.Span, syntax.OperatorToken.Text, boundLeft.Type, boundRight.Type);
                return new BoundErrorExpression();
            }
            return new BoundBinaryExpression(boundLeft, boundOperator, boundRight);
        }

        private VariableSymbol BindVariable( SyntaxToken identifier, bool IsReadOnly, TypeSymbol type)
        {
            var name = identifier.Text ?? "?";
            var declare = !identifier.IsMissing;
            var variable = new VariableSymbol(name, IsReadOnly, type);
            if (declare && !_scope.TryDeclare(variable))
                _diagnostics.ReportVariableAlreadyDeclared(identifier.Span, name);
            return variable;
        }
    }
}