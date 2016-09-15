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
        private readonly Tuple<String, IValueFinderFactory>[] _strategies;


        
        public PalindromeUI(IValueFinderFactory finderFactory) : 
            this(new Tuple<String, IValueFinderFactory>[] { new Tuple<string, IValueFinderFactory>("Default strategy", finderFactory) })
        { }

        public PalindromeUI(Tuple<String, IValueFinderFactory>[] strategies)
        {
            _strategies = strategies;
        }

        public void RunUI()
        {
            int digits;
            int strategyIndex;
            do
            {
                bool isValid;
                do
                {
                    Console.WriteLine("Please choose a strategy:");
                    Console.WriteLine("  0: Quit");
                    for (int i = 0; i < _strategies.Length; i++)
                    {
                        Console.WriteLine("  {0}: {1}", i + 1, _strategies[i].Item1);
                    }
                    Console.Write(" > ");
                    isValid = int.TryParse(Console.ReadLine(), out strategyIndex);
                    strategyIndex--;
                    if (!isValid || strategyIndex < -1 || strategyIndex >= _strategies.Length)
                    {
                        Console.WriteLine("Please enter a number in the given range.\n");
                    }
                } while (!isValid || strategyIndex < -1 || strategyIndex >= _strategies.Length);

                if (strategyIndex >= 0)
                {

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

                    IValueFinder finder = _strategies[strategyIndex].Item2.CreateValueFinder(digits);
                    Console.WriteLine(finder.FindValue());
                    Console.WriteLine("Press a key...");
                    Console.ReadKey(true);
                    Console.WriteLine();
                    
                }
            } while (strategyIndex >= 0);
        }
    }
}
