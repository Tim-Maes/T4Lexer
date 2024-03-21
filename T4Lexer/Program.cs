namespace T4Lexer;

internal class Program
{
    static void Main(string[] args)
    {
        var lexer = new T4Lexer("Hello <# control #> World <#= expression #>");

        foreach (var token in lexer.Tokenize())
        {
            Console.WriteLine(token);
        }

        Console.ReadKey();
    }
}
