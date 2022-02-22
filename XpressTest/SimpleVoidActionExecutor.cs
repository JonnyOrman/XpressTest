﻿namespace XpressTest;

public class SimpleVoidActionExecutor<TSut> : ISimpleVoidActionExecutor
{
    private readonly TSut _sut;
    private readonly System.Action<TSut> _action;

    public SimpleVoidActionExecutor(
        TSut sut,
        System.Action<TSut> action
        )
    {
        _sut = sut;
        _action = action;
    }

    public void Execute()
    {
        _action.Invoke(_sut);
    }
}
