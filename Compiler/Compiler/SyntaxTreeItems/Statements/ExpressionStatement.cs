﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Compiler.SyntaxTreeItems.Statements
{
    public class ExpressionStatement : Statement
    {
        public readonly Expression Expression;
        public readonly SemicolonToken? Semicolon;
        public ExpressionStatement(TokenCollection tokens)
        {
            var expression = Expression.ReadExpression(tokens);
            if (expression is ICompleteStatement)
            {
                Expression = expression;
                Semicolon = tokens.EnsureValidStatementEnding();
            }
            else throw new InvalidStatementException(expression);
        }
    }
}
