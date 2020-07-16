using System;
using System.Collections.Generic;
using System.Text;

namespace Compiler.SyntaxTreeItems
{
    public class PrimitiveTypeExpression : PrimaryExpression
    {
        public PrimitiveTypeToken PrimitiveType { get; private set; }

        public PrimitiveTypeExpression(TokenCollection tokens, PrimitiveTypeToken? primitiveType = null)
        {
            PrimitiveType = primitiveType == null ? tokens.PopToken<PrimitiveTypeToken>() : (PrimitiveTypeToken)primitiveType;
        }

        public override string ToString()
        {
            string ret = "";
            ret += PrimitiveType.ToString();
            return ret;
        }
    }
}
