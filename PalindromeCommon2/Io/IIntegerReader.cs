using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindromes.Io
{
    public interface IIntegerReader
    {
        /// <summary>
        /// Should always return a valid value. Should never throw an exception. In order to do this,
        /// implementations may need to use or implement IOutputWriter or otherwise notify the user
        /// of bad input.
        /// </summary>
        /// <returns></returns>
        int GetInt();

        /// <summary>
        /// Should always return a valid value. If min > max, the parameters should be interpreted as being in
        /// reversed order, so they always specify a valid range.
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        int GetInt(int min, int max);

        // Could add more functions like GetDouble, but they're not needed for this application.
    }
}
