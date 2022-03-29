using System.Collections.Generic;

namespace XpressTest.Examples.Src;

public class EventsRunner
{
    private readonly IEnumerable<IEvent> _events;

    public EventsRunner(
        IEnumerable<IEvent> events
        )
    {
        _events = events;
    }

    public void Run()
    {
        foreach (var e in _events)
        {
            e.Run();
        }
    }
}