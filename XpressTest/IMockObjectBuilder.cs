using System.Linq.Expressions;

namespace XpressTest;

public interface IMockObjectBuilder<TSut, TObject> : IObjectBuilder<TSut>
{
    IMockObjectBuilder<TSut, TObject> That<TObjectResult>(
        Expression<Func<TObject, TObjectResult>> func,
        TObjectResult objectResult
        );
}