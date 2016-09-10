namespace PalindromeCommon
{
    public interface IValueChecker<T>
    {
        bool IsValueValid(T value);
    }
}