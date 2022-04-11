namespace XpressTest;

public interface IMock<T>
    :
        IMock,
        IObject<T>
    where T : class
{
    Moq.Mock<T> MoqMock { get; }
}

public interface IMock
{
    
}