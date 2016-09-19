using Palindromes.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindromes.Io
{
    public class PalindromeUi
    {
        private const String DEFAULT_LINE_PROMPT = " > ";
        private const String DEFAULT_ERROR_MSG = "Please enter a number in the given range.";


        private readonly IList<IValueFinderStrategy> _strategies;
        private readonly Palindromes.Io.IUserOptionChooser _optionChooser;
        private readonly Palindromes.Io.IIntegerReader _reader;
        private readonly Palindromes.Io.IOutputWriter _writer;

        
        public PalindromeUi(IList<IValueFinderStrategy> strategies)
            : this(strategies, new Palindromes.Io.ConsoleWriter())
        { }

        public PalindromeUi(IList<IValueFinderStrategy> strategies, Palindromes.Io.IOutputWriter writer)
            : this(strategies, writer, new Palindromes.Io.ConsoleReaderWithPrompt(DEFAULT_LINE_PROMPT, DEFAULT_ERROR_MSG, writer))
        { }

        public PalindromeUi(IList<IValueFinderStrategy> strategies, Palindromes.Io.IOutputWriter writer, Palindromes.Io.IIntegerReader reader) 
            : this(strategies, writer, reader, new Palindromes.Io.UserOptionChooser(writer, reader))
        { }

        public PalindromeUi(IList<IValueFinderStrategy> strategies, Palindromes.Io.IOutputWriter writer, Palindromes.Io.IIntegerReader reader, Palindromes.Io.IUserOptionChooser optionChooser)
        {
            _strategies = strategies;
            _writer = writer;
            _reader = reader;
            _optionChooser = optionChooser;
        }

        public void RunUI()
        {
            ShowIntro();

            bool shouldContinue;
            do
            {
                shouldContinue = DoLoop();
            } while (shouldContinue);
        }

        private void ShowIntro()
        {
            _writer.WriteLine("This program finds the largest palindrome that is a multiple of");
            _writer.WriteLine("two N-digit numbers. For example, for N = 2, the highest palindrome");
            _writer.WriteLine("that is a multiple of two 2-digit numbers is 9009.");
            _writer.WriteLine("There are several ways available to calculate the result.");
            _writer.WriteLine("");
        }

        private bool DoLoop()
        {
            ValueFinderFactory finderFactory = ChooseStrategy();
            if (finderFactory == null) return false;

            int digits = ChooseNumberOfDigits();
            IValueFinder finder = finderFactory.Invoke(digits);
            long result = finder.FindValue();
            ShowResult(digits, result);

            return true;
        }

        private void ShowResult(int digits, long result)
        {
            _writer.Write("The highest palindromic multiple of two " + digits.ToString() + "-digit numbers is: ");
            _writer.WriteLine(result.ToString());
            _writer.WriteLine("");
        }

        private int ChooseNumberOfDigits()
        {
            _writer.WriteLine("How many digits are each factor (1-9)?");
            int digits = _reader.GetInt(1, 9);
            _writer.WriteLine("");
            return digits;
        }

        private ValueFinderFactory ChooseStrategy()
        {
            IValueFinderStrategy finderFactory;
            var quitStrategyAsList = new List<IValueFinderStrategy> { new NullValueFinderStrategy("Quit") };
            var strategiesIncludingQuit = quitStrategyAsList.Concat(_strategies).ToList();
            finderFactory = _optionChooser.GetOptionFromUser("Please choose a strategy:", strategiesIncludingQuit, 0);
            return finderFactory.CreateValueFinder;
        }

    }
}
