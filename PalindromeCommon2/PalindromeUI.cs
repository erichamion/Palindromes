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

        
        public PalindromeUI(IValueFinderFactory finderFactory) : 
            this(new Tuple<String, IValueFinderFactory>[] { new Tuple<string, IValueFinderFactory>("Default strategy", finderFactory) })
        { }

        public PalindromeUI(Tuple<String, IValueFinderFactory>[] strategies) 
            : this(strategies, new Palindromes.Io.UserOptionChooser(DEFAULT_LINE_PROMPT, DEFAULT_ERROR_MSG))
        { }

        public PalindromeUI(Tuple<String, IValueFinderFactory>[] strategies, Palindromes.Io.IUserOptionChooser optionChooser)
        {
            _strategies = strategies;
            _optionChooser = optionChooser;
        }

        public void RunUI()
        {
            int digits;
            IValueFinderFactory finderFactory;
            do
            {
                var quitStrategyAsList = new List<Tuple<String, IValueFinderFactory>> { new Tuple<String, IValueFinderFactory>("Quit", null) };
                var strategiesIncludingQuit = quitStrategyAsList.Concat(_strategies).ToList();
                finderFactory = _optionChooser.GetOptionFromUser("Please choose a strategy:", strategiesIncludingQuit, 0);

                if (finderFactory != null)
                {
                    bool isValid;
                    digits = -1;
                    do
                    {
                        Console.WriteLine("How many digits are each factor?");
                        Console.Write(" > ");
                        isValid = int.TryParse(Console.ReadLine(), out digits);
                        if (!isValid || digits <= 0)
                        {
                            Console.WriteLine("Please enter an integer between 1 and 9, inclusive.\n");
                        }
                    } while (!isValid || digits <= 0);

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
