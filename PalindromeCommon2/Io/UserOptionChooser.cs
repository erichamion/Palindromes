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
                    Console.WriteLine("  {0}: {1}", i, optionList[i].Item1);
                }
                Console.Write(" > ");
                isValid = int.TryParse(Console.ReadLine(), out chosenIndex);
                chosenIndex -= firstOptionNumber;
                if (!isValid || chosenIndex < -1 || chosenIndex >= optionList.Count())
                {
                    Console.WriteLine(errorMsg + "\n");
                }
            } while (!isValid || chosenIndex < -1 || chosenIndex >= optionList.Count());

            return optionList[chosenIndex].Item2;
        }
    }
}
