using Moq;

namespace XpressTest;

public interface IMockObjectSetter<TObject>
    :
        IObjectSetter<Mock<TObject>>
    where TObject : class
{
}