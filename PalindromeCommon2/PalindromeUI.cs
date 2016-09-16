using PalindromeCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalindromeCommon
{
    public class PalindromeUI
    {
        private const String DEFAULT_LINE_PROMPT = " > ";
        private const String DEFAULT_ERROR_MSG = "Please enter a number in the given range.";


        private readonly Tuple<String, IValueFinderFactory>[] _strategies;
        private readonly Palindromes.Io.IUserOptionChooser _optionChooser;
        private readonly Palindromes.Io.IIntegerReader _reader;
        private readonly Palindromes.Io.IOutputWriter _writer;

        
        public PalindromeUI(IValueFinderFactory finderFactory) : 
            this(new Tuple<String, IValueFinderFactory>[] { new Tuple<string, IValueFinderFactory>("Default strategy", finderFactory) })
        { }

        public PalindromeUI(Tuple<String, IValueFinderFactory>[] strategies)
            : this(strategies, new Palindromes.Io.ConsoleWriter())
        { }

        public PalindromeUI(Tuple<String, IValueFinderFactory>[] strategies, Palindromes.Io.IOutputWriter writer)
            : this(strategies, writer, new Palindromes.Io.ConsoleReaderWithPrompt(DEFAULT_LINE_PROMPT, DEFAULT_ERROR_MSG, writer))
        { }

        public PalindromeUI(Tuple<String, IValueFinderFactory>[] strategies, Palindromes.Io.IOutputWriter writer, Palindromes.Io.IIntegerReader reader) 
            : this(strategies, writer, reader, new Palindromes.Io.UserOptionChooser(writer, reader))
        { }

        public PalindromeUI(Tuple<String, IValueFinderFactory>[] strategies, Palindromes.Io.IOutputWriter writer, Palindromes.Io.IIntegerReader reader, Palindromes.Io.IUserOptionChooser optionChooser)
        {
            _strategies = strategies;
            _writer = writer;
            _reader = reader;
            _optionChooser = optionChooser;
        }

        public void RunUI()
        {
            IValueFinderFactory finderFactory;
            do
            {
                var quitStrategyAsList = new List<Tuple<String, IValueFinderFactory>> { new Tuple<String, IValueFinderFactory>("Quit", null) };
                var strategiesIncludingQuit = quitStrategyAsList.Concat(_strategies).ToList();
                finderFactory = _optionChooser.GetOptionFromUser("Please choose a strategy:", strategiesIncludingQuit, 0);

                if (finderFactory != null)
                {
                    _writer.WriteLine("How many digits are each factor (1-9)?");
                    int digits = _reader.GetInt(1, 9);
                     

                    IValueFinder finder = finderFactory.CreateValueFinder(digits);
                    Console.WriteLine(finder.FindValue());
                    Console.WriteLine("Press a key...");
                    Console.ReadKey(true);
                    Console.WriteLine();
                    
                }
            } while (finderFactory != null);
        }
    }
}
