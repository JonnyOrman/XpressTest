namespace XpressTest;

public interface IResultProvider<TResult>
{
    TResult Get();
}
