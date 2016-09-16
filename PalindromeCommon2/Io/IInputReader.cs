using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindromes.Io
{
    public interface IInputReader
    {
        String GetString();

        /// <summary>
        /// Should always return a valid value. Should never throw an exception. In order to do this,
        /// implementations may need to use or implement IOutputWriter or otherwise notify the user
        /// of bad input.
        /// </summary>
        /// <returns></returns>
        int GetInt();

        // Could add more functions like GetDouble, but they're not needed for this application.
    }
}
