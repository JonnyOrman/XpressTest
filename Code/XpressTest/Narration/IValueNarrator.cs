namespace XpressTest.Narration;

public interface IValueNarrator<TValue>
{
    void Narrate(TValue value);
}