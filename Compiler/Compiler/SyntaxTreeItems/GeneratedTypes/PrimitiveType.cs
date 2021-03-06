using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq;

namespace Compiler.SyntaxTreeItems
{
    public class PrimitiveType : Type
    {
        public PrimitiveTypeToken TypeKeyword { get; private set; }

        public PrimitiveType(TokenCollection tokens)
        {
            TypeKeyword = tokens.PopToken<PrimitiveTypeToken>();
        }

        public override string ToString()
        {
            string ret = "";
            ret += TypeKeyword.ToString();
            return ret;
        }
    }
}
