using System.Linq.Expressions;

namespace XpressTest;

public class MockVariableBuilderChainer<TSut, TMock, TVariable>
    :
        VariableBuilderChainer<TSut>,
        IMockBuilderChainer<TSut, TMock, TVariable>
    where TSut : class
    where TMock : class
    where TVariable : IMock<TMock>
{
    private readonly IArrangement _arrangement;

    public MockVariableBuilderChainer(
        ITestBuilderContainer<TSut> testBuilderContainer,
        IMockSetupBuilderCreator<TSut> mockSetupBuilderGenerator,
        IArrangement arrangement,
        INamedMockSetupBuilderCreator<TSut> namedMockObjectBuilderCreator
        )
        : base(
            testBuilderContainer,
            mockSetupBuilderGenerator,
            namedMockObjectBuilderCreator
        )
    {
        _arrangement = arrangement;
    }
    
    public IMockSetupResultBuilder<TSut, TMock, TResult> StartMockSetupResultBuilder<TResult>(
        Func<IReadArrangement, Expression<Func<TMock, TResult>>> func,
        TVariable mock,
        IMockSetupBuilder<TSut, TMock> mockObjectBuilder
    )
    {
        var expression = func.Invoke(_arrangement);
        
        return new MockResultObjectBuilder<TSut, TMock, TResult>(
            expression,
            mock,
            mockObjectBuilder,
            _arrangement
        );
    }

    public IMockSetupResultBuilder<TSut, TMock, TResult> StartMockSetupResultBuilder<TResult>(
        Expression<Func<TMock, TResult>> expression,
        TVariable mock,
        IMockSetupBuilder<TSut, TMock> mockObjectBuilder
    )
    {
        return new MockResultObjectBuilder<TSut, TMock, TResult>(
            expression,
            mock,
            mockObjectBuilder,
            _arrangement
        );
    }
}