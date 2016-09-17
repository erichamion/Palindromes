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

        private readonly IOutputWriter _writer;
        private readonly IIntegerReader _reader;

        public UserOptionChooser(IOutputWriter writer, IIntegerReader reader)
        {
            _writer = writer;
            _reader = reader;
        }

        public T GetOptionFromUser<T>(String prePrompt, IList<T> optionList) where T : Common.IDescribable
        {
            return GetOptionFromUser(prePrompt, optionList, DEFAULT_FIRST_OPTION_NUMBER);
        }

        public T GetOptionFromUser<T>(String prePrompt, IList<T> optionList, int firstOptionNumber) where T : Common.IDescribable
        {
            int userMinOption = firstOptionNumber;
            int userMaxOption = firstOptionNumber + optionList.Count - 1;

            _writer.WriteLine(prePrompt);
            for (int i = 0; i < optionList.Count(); i++)
            {
                // Add the starting number to the index for display
                _writer.WriteLine(String.Format("  {0}: {1}", i + firstOptionNumber, optionList[i].Description));
            }

            int userSelection = _reader.GetInt(userMinOption, userMaxOption);
            int chosenIndex = userSelection - firstOptionNumber;
            
            _writer.WriteLine("");

            return optionList[chosenIndex];
        }
    }
}
