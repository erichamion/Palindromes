﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindromes.Io
{
    public interface IOutputWriter
    {
        void Write(String outputStr);
        void WriteLine(String outputStr);
    }
}
