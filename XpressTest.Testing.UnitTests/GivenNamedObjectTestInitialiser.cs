using FluentAssertions;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenNamedObjectTestInitialiser
{
    [Fact]
    public void WhenItInitialisesATestWithANamedObjectThenItnitialisesANamedObjectVariableBuilder()
    {
        var obj = new object();

        var objectName = "ObjectName";

        var result = NamedObjectTestInitialiser<object, object>.Initialise(
            obj,
            objectName
        );

        result.Should().BeOfType<VariableBuilder<object, INamedObject<object>, IVariableBuilderChainer<object>>>();
    }
}