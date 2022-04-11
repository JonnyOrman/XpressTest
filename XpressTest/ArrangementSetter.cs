namespace XpressTest;

public class ArrangementSetter<T>
    :
        IArrangementSetter<T>
{
    private readonly IArrangement _arrangement;
    private readonly Action<IArrangement, T> _setAction;

    protected ArrangementSetter(
        IArrangement arrangement,
        Action<IArrangement, T> setAction
    )
    {
        _arrangement = arrangement;
        _setAction = setAction;
    }

    public void Set(T arrangementObject) =>
        _setAction.Invoke(_arrangement, arrangementObject);
}