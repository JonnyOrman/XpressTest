namespace XpressTest;

public interface IResultPropertyValueComparer<TProperty>
{
    void Compare(TProperty expectedValue);
}