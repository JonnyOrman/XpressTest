using System.Threading.Tasks;

namespace XpressTest.Testing.UnitTests.TestClasses;

public interface ITestAsyncInterface
{
    Task<object> GetAsync();
}