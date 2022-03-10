namespace XpressTest.Examples.Src;

public class VoidValueAndMockDependencyClass
{
    private readonly string _name;
    private readonly IVoidMockOneValueParameter _voidMock;

    public VoidValueAndMockDependencyClass(
        string name,
        IVoidMockOneValueParameter voidMock
        )
    {
        _name = name;
        _voidMock = voidMock;
    }

    public VoidValueAndMockDependencyClass(
        IVoidMockOneValueParameter voidMock,
        string name
        )
    {
        _voidMock = voidMock;
        _name = name;
    }

    public void Execute()
    {
        _voidMock.Execute(_name);
    }
}