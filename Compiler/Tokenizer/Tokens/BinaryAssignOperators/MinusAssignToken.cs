using System;
using System.Collections.Generic;
using System.Text;

namespace Tokenizer
{
    public struct MinusAssignToken : IToken
    {
        public string Text { get; private set; }
        public int Index { get; private set; }

        public MinusAssignToken(string text, int index)
        {
            Text = text;
            Index = index;
        }

        public override string ToString() => Text;
    }
}