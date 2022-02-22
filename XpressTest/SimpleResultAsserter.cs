﻿namespace XpressTest;

public class SimpleResultAsserter : ISimpleAsserter
{
    private readonly IExceptionAsserter _exceptionAsserter;

    public SimpleResultAsserter(
        IExceptionAsserter exceptionAsserter
        )
    {
        _exceptionAsserter = exceptionAsserter;
    }
    
    public void ThenItShouldThrow<TException>()
        where TException : Exception
    {
        _exceptionAsserter.Assert<TException>();
    }
}
