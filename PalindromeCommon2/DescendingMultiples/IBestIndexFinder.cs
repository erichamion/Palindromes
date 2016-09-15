using System.Collections.Generic;

namespace Palindromes.DescendingMultiples
{
    public interface IBestIndexFinder<T>
    {
        int FindIndex(IEnumerable<T> list);
    }
}