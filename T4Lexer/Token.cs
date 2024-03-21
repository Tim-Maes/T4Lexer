﻿namespace T4Lexer;

public class Token
{
    public TokenType Type { get; set; }

    public string Value { get; set; }

    public int Position { get; set; }

    public Token(TokenType type, string value, int position)
    {
        Type = type;
        Value = value;
        Position = position;
    }

    public override string ToString() => $"Type: {Type}, Value: {Value}, Position: {Position}";
}