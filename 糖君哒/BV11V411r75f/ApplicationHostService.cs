using System;
using System.Threading;
using System.Threading.Tasks;
//using AIStream.HuishangBank.DocumentBot;
using Microsoft.Extensions.Hosting;

namespace BV11V411r75f
{
    public class ApplicationHostService : IHostedService
    {
        private MainWindow _mainWindow;
        private readonly IServiceProvider _serviceProvider;

        public ApplicationHostService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            // Initialize services that you need before app activation
            await InitializeAsync();

            await HandleActivationAsync();

            // Tasks after activation
            await StartupAsync();
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }

        private async Task InitializeAsync()
        {
            await Task.CompletedTask;
        }

        private async Task StartupAsync()
        {
            await Task.CompletedTask;
        }

        private async Task HandleActivationAsync()
        {
            _mainWindow = _serviceProvider.GetService(typeof(MainWindow)) as MainWindow;
            _mainWindow.Show();
            await Task.CompletedTask;
        }
    }
}
