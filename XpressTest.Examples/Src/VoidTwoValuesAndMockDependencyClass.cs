namespace XpressTest.Examples.Src;

public class VoidTwoValuesAndMockDependencyClass
{
    private readonly string _parameter1;
    private readonly string _parameter2;
    private readonly IVoidMockTwoValueParameter _voidMockTwoValueParameter;

    public VoidTwoValuesAndMockDependencyClass(
        string parameter1,
        string parameter2,
        IVoidMockTwoValueParameter voidMockTwoValueParameter
        )
    {
        _parameter1 = parameter1;
        _parameter2 = parameter2;
        _voidMockTwoValueParameter = voidMockTwoValueParameter;
    }

    public VoidTwoValuesAndMockDependencyClass(
        IVoidMockTwoValueParameter voidMockTwoValueParameter,
        string parameter1,
        string parameter2
        )
    {
        _voidMockTwoValueParameter = voidMockTwoValueParameter;
        _parameter1 = parameter1;
        _parameter2 = parameter2;
    }

    public void Execute()
    {
        _voidMockTwoValueParameter.Execute(_parameter1, _parameter2);
    }
}