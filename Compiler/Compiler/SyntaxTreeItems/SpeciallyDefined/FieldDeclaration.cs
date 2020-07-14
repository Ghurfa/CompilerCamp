﻿using Compiler.SyntaxTreeItems;
using System;
using System.Collections.Generic;
using System.Text;

namespace Compiler
{
    public class FieldDeclaration : ClassItemDeclaration
    {
        public readonly IToken Name;
        
        public readonly IToken? ColonToken;
        public readonly ModifierList Modifiers;
        public readonly SyntaxTreeItems.Type Type;

        public readonly IToken? AssignmentToken;
        public readonly Expression DefaultValue;

        public readonly IToken? Semicolon;
        public FieldDeclaration(TokenCollection tokens, IToken identifierToken, IToken syntaxCharToken)
        {
            Name = identifierToken;
            
            if(syntaxCharToken.Type == TokenType.DeclAssign)
            {
                AssignmentToken = syntaxCharToken;
                DefaultValue = Expression.ReadExpression(tokens);
                if(tokens.PopIfMatches(out IToken colon, TokenType.Colon))
                {
                    ColonToken = colon;
                    Modifiers = new ModifierList(tokens);
                }
            }
            else
            {
                ColonToken = syntaxCharToken;
                Modifiers = new ModifierList(tokens);
                Type = SyntaxTreeItems.Type.ReadType(tokens);

                if(tokens.PopIfMatches(out IToken equals, TokenType.Assign))
                {
                    AssignmentToken = equals;
                    DefaultValue = Expression.ReadExpression(tokens);
                }
            }

            Semicolon = tokens.EnsureValidStatementEnding();
        }
    }
}