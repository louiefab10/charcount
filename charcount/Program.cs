class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Usage: charcount \"your text here\"");
            Console.WriteLine("     charcount --help");
            Console.WriteLine("     charcount --version");
            return;
        }

        if (args[0] == "--help" || args[0] == "--h")
        {
            ShowHelp();
            return;
        }

        if (args[0] == "--version" || args[0] == "--v")
        {
            Console.WriteLine("Version: " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version?.ToString());
            return;
        }
        string input = args.Length == 0
            ? Console.In.ReadToEnd()
            : string.Join(" ", args);
        
        CountText(input);
        
    }
    
    static void CountText(string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            Console.WriteLine("No text provided.");
            return;
        }
            
        int charCount = text.Count(c => !char.IsWhiteSpace(c));
            
        int wordCount = text.Split(new char[] { ' ', '\t', '\n', '\r' }, 
            StringSplitOptions.RemoveEmptyEntries).Length;
            
        Console.WriteLine($"{charCount} characters and {wordCount} words");
    }
    static void ShowHelp()
    {
        Console.WriteLine("💻 charcount Help");
        Console.WriteLine("------------------");
        Console.WriteLine("Usage:");
        Console.WriteLine("  charcount <command> [options]");
        Console.WriteLine();
        Console.WriteLine("Commands:");
        Console.WriteLine("  charcount \"string\" counts the characters and words in an entered string.");
        Console.WriteLine("  help             Show this help menu");
    }
}