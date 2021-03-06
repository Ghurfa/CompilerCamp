using System;
using System.Collections.Generic;
using System.Text;

namespace Compiler
{
    public struct CharLiteralToken : IToken
    {
        public string Text { get; private set; }
        public int Index { get; private set; }

        public CharLiteralToken(string text, int index)
        {
            Text = text;
            Index = index;
        }

        public override string ToString() => Text;
    }
}
