using System.Linq.Expressions;
using XpressTest.Narration;

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

    public IMockResultBuilder<TResult, IMockSetupBuilder<TSut, TMock>> StartMockSetupResultBuilder<TResult>(
        Func<IReadArrangement, Expression<Func<TMock, TResult>>> func,
        TVariable mock,
        IMockSetupBuilder<TSut, TMock> mockSetupBuilder
    )
    {
        var expression = func.Invoke(_arrangement);
        
        var resultNarrator = new FunctionResultNarrator<TResult>();

        return new MockResultBuilder<TMock, TResult, IMockSetupBuilder<TSut, TMock>>(
            expression,
            mock,
            mockSetupBuilder,
            _arrangement,
            resultNarrator
        );
    }

    public IMockResultBuilder<TResult, IMockSetupBuilder<TSut, TMock>> StartMockSetupResultBuilder<TResult>(
        Expression<Func<TMock, TResult>> expression,
        TVariable mock,
        IMockSetupBuilder<TSut, TMock> mockObjectBuilder
    )
    {
        var resultNarrator = new FunctionResultNarrator<TResult>();
        
        return new MockResultBuilder<TMock, TResult, IMockSetupBuilder<TSut, TMock>>(
            expression,
            mock,
            mockObjectBuilder,
            _arrangement,
            resultNarrator
        );
    }
}