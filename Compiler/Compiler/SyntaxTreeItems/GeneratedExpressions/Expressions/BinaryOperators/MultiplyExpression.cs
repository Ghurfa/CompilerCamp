using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compiler.SyntaxTreeItems
{
    public class MultiplyExpression : Expression
    {
        public override int Precedence => 2;

        public Expression Left { get; private set; }
        public AsteriskToken Multiply { get; private set; }
        public Expression Right { get; private set; }
        public override Expression LeftExpr { get => Left; set { Left = value; } }
        public override Expression RightExpr { get => Right; set { Right = value; } }

        public MultiplyExpression(TokenCollection tokens, Expression left)
        {
            Left = left;
            Multiply = tokens.PopToken<AsteriskToken>();
            Right = Expression.ReadExpression(tokens);
        }

        public override string ToString()
        {
            string ret = "";
            ret += Left.ToString();
            ret += Multiply.ToString();
            ret += Right.ToString();
            return ret;
        }
    }
}
