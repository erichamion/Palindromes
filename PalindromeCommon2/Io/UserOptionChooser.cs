using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindromes.Io
{
    public class UserOptionChooser : IUserOptionChooser
    {
        private const int DEFAULT_FIRST_OPTION_NUMBER = 1;

        public T GetOptionFromUser<T>(string prePrompt, IList<Tuple<string, T>> optionList, string errorMsg)
        {
            return GetOptionFromUser(prePrompt, optionList, errorMsg, DEFAULT_FIRST_OPTION_NUMBER);
        }

        public T GetOptionFromUser<T>(string prePrompt, IList<Tuple<string, T>> optionList, string errorMsg, int firstOptionNumber)
        {
            bool isValid;
            int chosenIndex;
            do
            {
                Console.WriteLine(prePrompt);
                for (int i = 0; i < optionList.Count(); i++)
                {
                    // Add the starting number to the index for display
                    Console.WriteLine("  {0}: {1}", i + firstOptionNumber, optionList[i].Item1);
                }
                Console.Write(" > ");
                isValid = int.TryParse(Console.ReadLine(), out chosenIndex);

                // Subtract the starting number to convert from displayed number to index
                chosenIndex -= firstOptionNumber;
                if (!isValid || chosenIndex < 0 || chosenIndex >= optionList.Count())
                {
                    Console.WriteLine(errorMsg + "\n");
                }
            } while (!isValid || chosenIndex < 0 || chosenIndex >= optionList.Count());

            return optionList[chosenIndex].Item2;
        }
    }
}
