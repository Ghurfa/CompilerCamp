using System;
using System.Collections.Generic;
using System.Text;
using Compiler.SyntaxTreeItems.Statements;

namespace Compiler.SyntaxTreeItems
{
    public class LeftShiftAssignExpression : Expression, ICompleteStatement
    {
        public UnaryExpression To { get; private set; }
        public LeftShiftAssignToken LeftShiftAssign { get; private set; }
        public Expression From { get; private set; }

        public override int Precedence => 14;

        public override Expression LeftExpr { get => To; set => throw new InvalidOperationException() }
        public override Expression RightExpr { get => To; set => throw new InvalidOperationException() }

        public LeftShiftAssignExpression(TokenCollection tokens, UnaryExpression to = null, LeftShiftAssignToken? leftShiftAssign = null, Expression from = null)
        {
            To = to == null ? UnaryExpression.ReadUnaryExpression(tokens) : to;
            LeftShiftAssign = leftShiftAssign == null ? tokens.PopToken<LeftShiftAssignToken>() : (LeftShiftAssignToken)leftShiftAssign;
            From = from == null ? Expression.ReadExpression(tokens) : from;
        }

        public override string ToString()
        {
            string ret = "";
            ret += To.ToString();
            ret += LeftShiftAssign.ToString();
            ret += From.ToString();
            return ret;
        }
    }
}
