namespace XpressTest;

public interface IMockSetupResultBuilder<TSut, TObject, TResult>
:
    IReturnsMockBuilder<TResult, IMockSetupBuilder<TSut, TObject>> 
{
    IMockSetupBuilder<TSut, TObject> AndReturns(
        Func<IReadArrangement, TResult> func
        );
    
    IMockSetupBuilder<TSut, TObject> AndReturns(
        TResult expectedResult
        );
}