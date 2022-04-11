namespace XpressTest;

public interface IDependencyBuilder<TSut>
:
    IDependenciesBuilder<TSut>,
    IActor<TSut>
{
}