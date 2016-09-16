using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindromes.Io
{
    public class ConsoleReaderWithPrompt : IIntegerReader
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
            return GetInt(int.MinValue, int.MaxValue);
        }

        public int GetInt(int min, int max)
        {
            int effectiveMin = Math.Min(min, max);
            int effectiveMax = Math.Max(min, max);

            int result;
            bool isValid;
            do
            {
                isValid = int.TryParse(GetString(), out result);
                if (!isValid || result < effectiveMin || result > effectiveMax)
                {
                    _writer.WriteLine(_invalidIntMessage);
                }
            } while (!isValid || result < effectiveMin || result > effectiveMax);

            return result;
        }

        private string GetString()
        {
            _writer.Write(_prompt);
            return Console.ReadLine();
        }


    }
}
