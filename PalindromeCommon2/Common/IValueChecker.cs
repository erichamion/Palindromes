namespace Palindromes.Common
{
    public interface IValueChecker<T>
    {
        bool IsValueValid(T value);
    }
}