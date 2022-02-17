namespace XpressTest;

public interface IAsserter<TAssertion>
{
    ITester ThenItShould(TAssertion assertion);
}