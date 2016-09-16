using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindromes.Io
{
    class ConsoleKeypressWaiter : IUserInteractionWaiter
    {
        public void WaitForUserInteraction()
        {
            Console.ReadKey(true);
        }
    }
}
