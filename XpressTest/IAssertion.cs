using Moq;

namespace XpressTest;

public interface IAssertion<TResult> : IAssertion
{
    TResult Result { get; }
}

public interface IAssertion : IArrangement
{
    Mock<T> GetMock<T>()
        where T : class;
}