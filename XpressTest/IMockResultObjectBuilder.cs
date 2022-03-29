namespace XpressTest;

public interface IMockResultObjectBuilder<TSut, TObject, TResult>
{
    IMockObjectBuilder<TSut, TObject> AndReturns(
        Func<IArrangement, TResult> func
        );
    
    IMockObjectBuilder<TSut, TObject> AndReturns(
        TResult expectedResult
        );

    IMockObjectBuilder<TSut, TObject> AndReturns<TMock>()
        where TMock : class, TResult;
}