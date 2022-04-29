namespace XpressTest;

public class Builder<TObject, TChainer>
{
    protected readonly TObject Obj;
    protected readonly IArrangementSetter<TObject> ObjectSetter;
    protected readonly TChainer Chainer;

    protected Builder(
        TObject obj,
        IArrangementSetter<TObject> objectSetter,
        TChainer chainer
        )
    {
        Obj = obj;
        ObjectSetter = objectSetter;
        Chainer = chainer;
    }

    protected T Chain<T>(Func<T> func)
    {
        ObjectSetter.Set(Obj);

        return func.Invoke();
    }
}