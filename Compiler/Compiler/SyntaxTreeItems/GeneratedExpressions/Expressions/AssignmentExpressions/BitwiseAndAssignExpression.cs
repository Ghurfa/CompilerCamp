using System;
using System.Collections.Generic;
using System.Text;
using Compiler.SyntaxTreeItems.Statements;

namespace Compiler.SyntaxTreeItems
{
    public class BitwiseAndAssignExpression : Expression, ICompleteStatement
    {
        public UnaryExpression To { get; private set; }
        public BitwiseAndAssignToken BitwiseAndAssign { get; private set; }
        public Expression From { get; private set; }

        public override int Precedence => 14;

        public override Expression LeftExpr { get => To; set => throw new InvalidOperationException() }
        public override Expression RightExpr { get => To; set => throw new InvalidOperationException() }

        public BitwiseAndAssignExpression(TokenCollection tokens, UnaryExpression to = null, BitwiseAndAssignToken? bitwiseAndAssign = null, Expression from = null)
        {
            To = to == null ? UnaryExpression.ReadUnaryExpression(tokens) : to;
            BitwiseAndAssign = bitwiseAndAssign == null ? tokens.PopToken<BitwiseAndAssignToken>() : (BitwiseAndAssignToken)bitwiseAndAssign;
            From = from == null ? Expression.ReadExpression(tokens) : from;
        }

        public override string ToString()
        {
            string ret = "";
            ret += To.ToString();
            ret += BitwiseAndAssign.ToString();
            ret += From.ToString();
            return ret;
        }
    }
}
