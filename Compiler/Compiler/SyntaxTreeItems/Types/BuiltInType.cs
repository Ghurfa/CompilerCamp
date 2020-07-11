﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Compiler.SyntaxTreeItems.Types
{
    public class BuiltInType : Type
    {
        public readonly Token TypeToken;

        public BuiltInType(TokenCollection tokens)
        {
            TypeToken = tokens.PopToken(TokenType.PrimitiveType);
        }
    }
}