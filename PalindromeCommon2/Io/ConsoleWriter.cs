using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindromes.Io
{
    public class ConsoleWriter : IOutputWriter
    {
        public void Write(string outputStr)
        {
            Console.Write(outputStr);
        }

        public void WriteLine(string outputStr)
        {
            Console.WriteLine(outputStr);
        }
    }
}
