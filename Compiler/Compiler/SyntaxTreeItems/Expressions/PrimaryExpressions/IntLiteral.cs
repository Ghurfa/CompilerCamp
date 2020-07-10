﻿using Compiler.SyntaxTreeItems.Expressions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Compiler.SyntaxTreeItems
{
    public class IntLiteral : PrimaryExpression
    {
        public readonly Token Token;

        public IntLiteral(TokenCollection tokens, Token token)
        {
            Token = token;
        }
    }
}