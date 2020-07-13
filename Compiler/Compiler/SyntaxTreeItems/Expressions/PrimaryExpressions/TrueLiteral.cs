﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Compiler.SyntaxTreeItems.Expressions.PrimaryExpressions
{
    public class TrueLiteral : PrimaryExpression
    {
        public readonly Token TrueKeyword;
        public TrueLiteral(TokenCollection tokens, Token trueKeyword)
        {
            TrueKeyword = trueKeyword;
        }
        public override string ToString()
        {
            return TrueKeyword.ToString();
        }
    }
}