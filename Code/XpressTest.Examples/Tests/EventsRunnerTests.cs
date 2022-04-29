using Moq;
using System.Collections.Generic;
using XpressTest.Examples.Src;
using Xunit;

namespace XpressTest.Examples.Tests;

public class EventsRunnerTests
{
    [Fact]
    public void Test_Example1() =>
        GivenA<EventsRunner>
                .AndGivenA<IEvent>()
                .AndGiven(arrangement => new List<IEvent>
                {
                    arrangement.GetTheMockObject<IEvent>()
                })
            .WithThe<List<IEvent>>()
            .WhenIt(sut => sut.Run())
            .Then(assertion =>
            {
                assertion.GetTheMoq<IEvent>().Verify(event1 => event1.Run(), Times.Once);
            });

    [Fact]
    public void Test_Example2()
    {
        var event1 = new Moq.Mock<IEvent>();

        GivenA<EventsRunner>
                .AndGiven(new List<IEvent>
                {
                    event1.Object
                })
            .WithThe<List<IEvent>>()
            .WhenIt(sut => sut.Run())
            .Then(assertion =>
            {
                event1.Verify(event1 => event1.Run(), Times.Once);
            });
    }

    [Fact]
    public void Test_Example3()
    {
        var event1 = new Moq.Mock<IEvent>();

        var events = new List<IEvent>
        {
            event1.Object
        };

        GivenA<EventsRunner>
            .With(events)
            .WhenIt(sut => sut.Run())
            .Then(assertion =>
            {
                event1.Verify(event1 => event1.Run(), Times.Once);
            });
    }

    [Fact]
    public void Test_Example4()
    {
        var event1 = new Moq.Mock<IEvent>();

        var events = new List<IEvent>
        {
            event1.Object
        };

        GivenA<EventsRunner>
                .AndGiven(events)
            .WithThe<List<IEvent>>()
            .WhenIt(sut => sut.Run())
            .Then(assertion =>
            {
                event1.Verify(event1 => event1.Run(), Times.Once);
            });
    }

    [Fact]
    public void Test_Example5() =>
        GivenA<EventsRunner>
                .AndGivenA<IEvent>()
            .With<IEnumerable<IEvent>>(arrangement => new List<IEvent>
            {
                arrangement.GetTheMockObject<IEvent>()
            })
            .WhenIt(sut => sut.Run())
            .Then(assertion =>
            {
                assertion.GetTheMoq<IEvent>().Verify(event1 => event1.Run(), Times.Once);
            });

    [Fact]
    public void Test_Example6() =>
        GivenA<EventsRunner>
                .AndGivenA<IEvent>()
                .AndGiven(arrangement => new List<IEvent>
                {
                    arrangement.GetTheMockObject<IEvent>()
                }, "EventCollection")
            .WithThe<List<IEvent>>("EventCollection")
            .WhenIt(sut => sut.Run())
            .Then(assertion =>
            {
                assertion.GetTheMoq<IEvent>().Verify(event1 => event1.Run(), Times.Once);
            });
}