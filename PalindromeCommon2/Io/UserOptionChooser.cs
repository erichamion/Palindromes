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
        private readonly String _errorMsg;

        public UserOptionChooser(String linePrompt, String errorMsg, IOutputWriter writer = null, IIntegerReader reader = null)
        {
            _errorMsg = errorMsg;

            _writer = (writer != null) ? writer : new ConsoleWriter();
            _reader = (reader != null) ? reader : new ConsoleReaderWithPrompt(linePrompt, _errorMsg, _writer);
        }

        public T GetOptionFromUser<T>(String prePrompt, IList<Tuple<string, T>> optionList)
        {
            return GetOptionFromUser(prePrompt, optionList, DEFAULT_FIRST_OPTION_NUMBER);
        }

        public T GetOptionFromUser<T>(String prePrompt, IList<Tuple<string, T>> optionList, int firstOptionNumber)
        {
            int userMinOption = firstOptionNumber;
            int userMaxOption = firstOptionNumber + optionList.Count - 1;

            _writer.WriteLine(prePrompt);
            for (int i = 0; i < optionList.Count(); i++)
            {
                // Add the starting number to the index for display
                _writer.WriteLine(String.Format("  {0}: {1}", i + firstOptionNumber, optionList[i].Item1));
            }

            int userSelection = _reader.GetInt(userMinOption, userMaxOption);
            int chosenIndex = userSelection - firstOptionNumber;
            
            _writer.WriteLine("");

            return optionList[chosenIndex].Item2;
        }
    }
}
