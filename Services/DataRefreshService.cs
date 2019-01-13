using System;
using System.Threading;
using System.Threading.Tasks;

namespace BackgroundService.Services
{
    public class DataRefreshService : HostedService
    {
        private readonly IRandomStringProvider _randomStringProvider;

        public DataRefreshService(IRandomStringProvider randomStringProvider)
        {
            _randomStringProvider = randomStringProvider;
        }
        
        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                await _randomStringProvider.UpdateString(cancellationToken);
                await Task.Delay(TimeSpan.FromSeconds(5), cancellationToken);
            }
        }
    }
}