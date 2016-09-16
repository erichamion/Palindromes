using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindromes.Io
{
    public interface IUserOptionChooser
    {
        T GetOptionFromUser<T>(String prePrompt, IList<Tuple<String, T>> optionList, String errorMsg);
        T GetOptionFromUser<T>(String prePrompt, IList<Tuple<String, T>> optionList, String errorMsg, int firstOptionNumber);
    }
}
