namespace XpressTest;

public interface IValueDependencyBuilder<TSut>
    :
        IConstructedSutAsserter<TSut>
{
    IVoidAsserter<TSut> WhenIt(System.Action<TSut> func);
}