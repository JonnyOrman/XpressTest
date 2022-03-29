namespace XpressTest;

public interface INamedMockResultObjectBuilder<TSut, TObject, TResult>
{
    INamedMockObjectBuilder<TSut, TObject> AndReturns(
        TResult expectedResult
        );
}