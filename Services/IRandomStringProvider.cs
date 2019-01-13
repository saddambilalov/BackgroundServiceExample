using System.Threading;
using System.Threading.Tasks;

namespace BackgroundService.Services
{
    public interface IRandomStringProvider
    {
        string RandomString { get; }

        Task UpdateString(CancellationToken cancellationToken);
    }
}