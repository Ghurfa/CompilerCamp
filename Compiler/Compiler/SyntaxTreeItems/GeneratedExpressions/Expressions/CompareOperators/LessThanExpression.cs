using System;
using System.Collections.Generic;
using System.Text;

namespace Compiler.SyntaxTreeItems
{
    public class LessThanExpression : Expression
    {
        public Expression Left { get; private set; }
        public LessThanToken LessThan { get; private set; }
        public Expression Right { get; private set; }

        public override int Precedence => 5;

        public override Expression LeftExpr { get => Left; set { Left = value; } }
        public override Expression RightExpr { get => Left; set { Left = value; } }

        public LessThanExpression(TokenCollection tokens, Expression left = null, LessThanToken? lessThan = null, Expression right = null)
        {
            Left = left == null ? Expression.ReadExpression(tokens) : left;
            LessThan = lessThan == null ? tokens.PopToken<LessThanToken>() : (LessThanToken)lessThan;
            Right = right == null ? Expression.ReadExpression(tokens) : right;
        }

        public override string ToString()
        {
            string ret = "";
            ret += Left.ToString();
            ret += LessThan.ToString();
            ret += Right.ToString();
            return ret;
        }
    }
}
