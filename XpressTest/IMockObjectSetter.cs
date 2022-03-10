using Moq;

namespace XpressTest;

public interface IMockObjectSetter<TObject>
    where TObject : class
{
    void Set(Mock<TObject> mock);
}