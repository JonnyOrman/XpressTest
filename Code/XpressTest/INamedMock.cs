namespace XpressTest;

public interface INamedMock<T>
    :
        IMock<T>,
        INamedObject<T>
    where T : class
{
}
