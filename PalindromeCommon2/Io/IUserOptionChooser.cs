using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindromes.Io
{
    public interface IUserOptionChooser
    {
        T GetOptionFromUser<T>(String prePrompt, IList<T> optionList) where T : Common.IDescribable;
        T GetOptionFromUser<T>(String prePrompt, IList<T> optionList, int firstOptionNumber) where T : Common.IDescribable;
    }
}
