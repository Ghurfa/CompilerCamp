﻿using System;
using System.Collections.Generic;

namespace Compiler.SyntaxTreeItems
{
    public class MethodDeclaration : ClassItemDeclaration
    {
        public readonly IdentifierToken Name;
        public readonly ModifierList Modifiers;
        public readonly Type ReturnType;
        public readonly ParameterListDeclaration ParameterList;
        public readonly MethodBodyDeclaration MethodBody;
        public MethodDeclaration(TokenCollection tokens, IdentifierToken identifier)
        {
            Name = identifier;
            Modifiers = new ModifierList(tokens);
            ReturnType = Type.ReadType(tokens);
            ParameterList = new ParameterListDeclaration(tokens);
            MethodBody = new MethodBodyDeclaration(tokens);
        }
    }
}