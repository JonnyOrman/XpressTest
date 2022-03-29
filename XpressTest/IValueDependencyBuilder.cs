namespace XpressTest;

public interface IValueDependencyBuilder<TSut>
    :
        IConstructedSutAsserter<TSut>
{
    IVoidAsserter<TSut> WhenIt(System.Action<TSut> func);

    IMockDependencyBuilder<TSut, TMockDependency> WithA<TMockDependency>()
        where TMockDependency : class;
    
    IMockDependencyBuilder<TSut, TMockDependency> WithA<TMockDependency>(string name)
        where TMockDependency : class;
}