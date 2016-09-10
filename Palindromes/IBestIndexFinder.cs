using System.Collections.Generic;

namespace Palindromes
{
    public interface IBestIndexFinder<T>
    {
        int FindIndex(IEnumerable<T> list);
    }
}