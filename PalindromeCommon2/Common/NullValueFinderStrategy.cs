using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindromes.Common
{
    public class NullValueFinderStrategy : IValueFinderStrategy
    {
        public string Description { get; protected set; }

        public ValueFinderFactory CreateValueFinder { get; } = null;

        public NullValueFinderStrategy(String description)
        {
            Description = description;
        }

        
    }
}
