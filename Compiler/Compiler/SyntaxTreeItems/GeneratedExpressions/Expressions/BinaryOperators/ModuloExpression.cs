using System;
using System.Collections.Generic;
using System.Text;

namespace Compiler.SyntaxTreeItems
{
    public class ModuloExpression : Expression
    {
        public Expression Left { get; private set; }
        public ModuloToken Modulo { get; private set; }
        public Expression Right { get; private set; }

        public override int Precedence => 2;

        public override Expression LeftExpr { get => Left; set { Left = value; } }
        public override Expression RightExpr { get => Left; set { Left = value; } }

        public ModuloExpression(TokenCollection tokens, Expression left = null, ModuloToken? modulo = null, Expression right = null)
        {
            Left = left == null ? Expression.ReadExpression(tokens) : left;
            Modulo = modulo == null ? tokens.PopToken<ModuloToken>() : (ModuloToken)modulo;
            Right = right == null ? Expression.ReadExpression(tokens) : right;
        }

        public override string ToString()
        {
            string ret = "";
            ret += Left.ToString();
            ret += Modulo.ToString();
            ret += Right.ToString();
            return ret;
        }
    }
}
