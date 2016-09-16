using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindromes.Io
{
    public interface IUserOptionChooser
    {
        T GetOptionFromUser<T>(String prePrompt, IList<Tuple<string, T>> optionList);
        T GetOptionFromUser<T>(String prePrompt, IList<Tuple<string, T>> optionList, int firstOptionNumber);
    }
}
