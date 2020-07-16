using System;
using System.Collections.Generic;
using System.Text;
using Compiler.SyntaxTreeItems.Statements;

namespace Compiler.SyntaxTreeItems
{
    public class DivideAssignExpression : Expression, ICompleteStatement
    {
        public UnaryExpression To { get; private set; }
        public DivideAssignToken DivideAssign { get; private set; }
        public Expression From { get; private set; }

        public override int Precedence => 14;

        public override Expression LeftExpr { get => To; set => throw new InvalidOperationException() }
        public override Expression RightExpr { get => To; set => throw new InvalidOperationException() }

        public DivideAssignExpression(TokenCollection tokens, UnaryExpression to = null, DivideAssignToken? divideAssign = null, Expression from = null)
        {
            To = to == null ? UnaryExpression.ReadUnaryExpression(tokens) : to;
            DivideAssign = divideAssign == null ? tokens.PopToken<DivideAssignToken>() : (DivideAssignToken)divideAssign;
            From = from == null ? Expression.ReadExpression(tokens) : from;
        }

        public override string ToString()
        {
            string ret = "";
            ret += To.ToString();
            ret += DivideAssign.ToString();
            ret += From.ToString();
            return ret;
        }
    }
}
