namespace XpressTest;

public interface IVariablesBuilder<TSut>
    :
        IGivenNamedObjectBuilder<TSut>,
        IGivenArrangementObjectBuilder<TSut>,
        IGivenNamedArrangementObjectBuilder<TSut>,
        IGivenAMockBuilder<TSut>,
        IGivenNamedMockBuilder<TSut>,
        IGivenObjectBuilder<TSut>
{
}