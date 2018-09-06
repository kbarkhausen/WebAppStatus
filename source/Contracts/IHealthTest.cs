using WebAppStatus.Models;

namespace WebAppStatus.Contracts
{
    public interface IHealthTest
    {
        TestResult Run();
    }
}
