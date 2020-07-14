﻿using Compiler.SyntaxTreeItems.Expressions.PrimaryExpressions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Compiler.SyntaxTreeItems.Expressions
{
    public abstract class PrimaryExpression : UnaryExpression
    {
        public static PrimaryExpression ReadPrimaryExpression(TokenCollection tokens)
        {
            PrimaryExpression baseExpr;

            if (tokens.PopIfMatches(out IToken openPeren, TokenType.OpenPeren))
            {
                Expression innerExpr = Expression.ReadExpression(tokens);
                if (tokens.PopIfMatches(out IToken closePeren, TokenType.ClosePeren))
                {
                    baseExpr = new PerenthesizedExpression(tokens, openPeren, innerExpr, closePeren);
                }
                else if (tokens.PopIfMatches(out IToken comma, TokenType.Comma))
                {
                    baseExpr = new TupleExpression(tokens, openPeren, innerExpr, comma);
                }
                else throw new InvalidTokenException(tokens.PeekToken());
            }
            else if (tokens.PopIfMatches(out IToken newKeyword, TokenType.NewKeyword))
            {
                baseExpr = new NewObjectExpression(tokens, newKeyword);
            }
            else if (tokens.PopIfMatches(out IToken identifier, TokenType.Identifier))
            {
                if(tokens.PopIfMatches(out IToken colonToken, TokenType.Colon))
                {
                    baseExpr = new DeclarationExpression(tokens, identifier, colonToken);
                }
                else
                {
                    baseExpr = new IdentifierExpression(tokens, identifier);
                }
            }
            else if (tokens.PopIfMatches(out IToken intToken, TokenType.IntLiteral))
            {
                baseExpr = new IntLiteral(tokens, intToken);
            }
            else if (tokens.PopIfMatches(out IToken trueKeyword, TokenType.TrueKeyword))
            {
                baseExpr = new TrueLiteral(tokens, trueKeyword);
            }
            else if (tokens.PopIfMatches(out IToken falseKeyword, TokenType.FalseKeyword))
            {
                baseExpr = new FalseLiteral(tokens, falseKeyword);
            }
            else if (tokens.PopIfMatches(out IToken strOpenToken, TokenType.DoubleQuote))
            {
                baseExpr = new StringLiteral(tokens, strOpenToken);
            }
            else if (tokens.PopIfMatches(out IToken charOpenToken, TokenType.SingleQuote))
            {
                baseExpr = new CharLiteral(tokens, charOpenToken);
            }
            else if (tokens.PopIfMatches(out IToken valueKeyword, TokenType.ValueKeyword))
            {
                baseExpr = new ValueKeywordExpression(tokens, valueKeyword);
            }
            else if (tokens.PopIfMatches(out IToken primitiveKeyword, TokenType.PrimitiveType))
            {
                baseExpr = new PrimitiveTypeExpression(tokens, primitiveKeyword);
            }
            else throw new InvalidTokenException(tokens.PeekToken());

            PrimaryExpression exprSoFar = baseExpr;
            bool finishedParsing = false;
            while (!finishedParsing)
            {
                switch (tokens.PeekToken().Type)
                {
                    case TokenType.Dot:                 exprSoFar = new MemberAccessExpression(tokens, exprSoFar);  break;
                    case TokenType.OpenPeren:           exprSoFar = new MethodCallExpression(tokens, exprSoFar);    break;
                    case TokenType.OpenBracket:         exprSoFar = new ArrayAccessExpression(tokens, exprSoFar);   break;
                    case TokenType.Increment:           exprSoFar = new PostIncrementExpression(tokens, exprSoFar); break;
                    case TokenType.Decrement:           exprSoFar = new PostDecrementExpression(tokens, exprSoFar); break;
                    case TokenType.NullCondDot:         exprSoFar = new MemberAccessExpression(tokens, exprSoFar);  break;
                    case TokenType.NullCondOpenBracket: exprSoFar = new MethodCallExpression(tokens, exprSoFar);    break;
                    default: finishedParsing = true; break;
                }
            }
            return exprSoFar;
        }
    }
}
