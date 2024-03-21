namespace T4Lexer;

public class T4Lexer
{
    private readonly string _input;
    private int _position;

    public T4Lexer(string input)
    {
        _input = input;
        _position = 0;
    }

    public IEnumerable<Token> Tokenize()
    {
        while (_position < _input.Length)
        {
            if (_input[_position] == '<' && _input.Substring(_position).StartsWith("<#"))
            {
                string openingTag = DetectOpeningTag();

                yield return new Token(TokenType.OpeningTag, openingTag, _position);

                _position += openingTag.Length;
            }
            else if (_input[_position] == '#' && _input.Substring(_position).StartsWith("#>"))
            {
                yield return new Token(TokenType.ClosingTag, "#>", _position);

                _position += 2;
            }
            else
            {
                // Accumulate text until the next T4 token or end of file
                int start = _position;

                while (_position < _input.Length && !_input.Substring(_position).StartsWith("<#") && !_input.Substring(_position).StartsWith("#>"))
                {
                    _position++;
                }

                string textValue = _input.Substring(start, _position - start);

                yield return new Token(TokenType.Text, textValue, start);
            }
        }

        yield return new Token(TokenType.EOF, "", _position);
    }

    private string DetectOpeningTag()
    {
        if (_input.Substring(_position).StartsWith("<#="))
            return "<#=";
        else if (_input.Substring(_position).StartsWith("<#+"))
            return "<#+";
        else if (_input.Substring(_position).StartsWith("<#@"))
            return "<#@";
        else
            return "<#";
    }
}