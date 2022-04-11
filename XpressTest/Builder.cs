namespace XpressTest;

public class Builder<TObject, TChainer>
{
    protected readonly TObject _obj;
    protected readonly IArrangementSetter<TObject> _objectSetter;
    protected readonly TChainer _chainer;

    public Builder(
        TObject obj,
        IArrangementSetter<TObject> objectSetter,
        TChainer chainer
        )
    {
        _obj = obj;
        _objectSetter = objectSetter;
        _chainer = chainer;
    }
    
    protected T Chain<T>(Func<T> func)
    {
        _objectSetter.Set(_obj);

        return func.Invoke();
    }
}