using System.Linq.Expressions;

namespace XpressTest;

public class NamedMockObjectBuilder<TSut, TObject>
    :
        INamedMockObjectBuilder<TSut, TObject>
    where TSut : class
    where TObject : class
{
    private readonly INamedMock<TObject> _namedMock;
    private readonly IArrangement _arrangement;
    private readonly INamedMockObjectSetter<TObject> _namedMockObjectSetter;
    private readonly IVoidAsserterCreator<TSut> _voidAsserterCreator;

    public NamedMockObjectBuilder(
        INamedMock<TObject> namedMock,
        IArrangement arrangement,
        INamedMockObjectSetter<TObject> namedMockObjectSetter,
        IVoidAsserterCreator<TSut> voidAsserterCreator
        )
    {
        _namedMock = namedMock;
        _arrangement = arrangement;
        _namedMockObjectSetter = namedMockObjectSetter;
        _voidAsserterCreator = voidAsserterCreator;
    }

    public IVoidAsserter<TSut> WhenIt(
        System.Action<IAction<TSut>> func
        )
    {
        _arrangement.MockObjects.Add(_namedMock);
        
        return _voidAsserterCreator.Create(
            func
            );
    }

    public INamedMockObjectBuilder<TSut, TNewObject> AndGivenA<TNewObject>(
        string name
        ) where TNewObject : class
    {
        _namedMockObjectSetter.Set(_namedMock);
        
        var namedMock = NamedMockInitialiser<TNewObject>.Initialise(name);
        
        var namedMockObjectSetter = new NamedMockObjectSetter<TNewObject>(
            _arrangement
        );

        return new NamedMockObjectBuilder<TSut, TNewObject>(
            namedMock,
            _arrangement,
            namedMockObjectSetter,
            _voidAsserterCreator
        );
    }

    public INamedMockResultObjectBuilder<TSut, TObject, TResult> ThatDoes<TResult>(
        Expression<Func<TObject, TResult>> expression
        )
    {
        return new NamedMockResultObjectBuilder<TSut, TObject, TResult>(
            expression,
            _namedMock,
            this
        );
    }
}