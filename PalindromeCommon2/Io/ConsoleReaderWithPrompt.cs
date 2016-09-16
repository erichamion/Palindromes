using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindromes.Io
{
    public class ConsoleReaderWithPrompt : IInputReader
    {
        private readonly String _prompt;
        private readonly String _invalidIntMessage;
        private readonly IOutputWriter _writer;

        public ConsoleReaderWithPrompt(String prompt, String invalidIntMessage, IOutputWriter writer)
        {
            _prompt = prompt;
            _invalidIntMessage = invalidIntMessage;
            _writer = writer;
        }

        public int GetInt()
        {
            int result;
            bool isValid;
            do
            {
                isValid = int.TryParse(GetString(), out result);
                if (!isValid)
                {
                    _writer.WriteLine(_invalidIntMessage);
                }
            } while (!isValid);

            return result;
        }

        public string GetString()
        {
            _writer.Write(_prompt);
            return Console.ReadLine();
        }
    }
}
