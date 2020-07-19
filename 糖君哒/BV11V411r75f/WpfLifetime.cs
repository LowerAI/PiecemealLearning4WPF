using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BV11V411r75f
{
    public sealed class WpfLifetime : IHostLifetime, IDisposable
    {
        private readonly ManualResetEvent _shutdownBlock = new ManualResetEvent(initialState: false);

        private CancellationTokenRegistration _applicationStartedRegistration;

        private CancellationTokenRegistration _applicationStoppingRegistration;

        private ConsoleLifetimeOptions Options
        {
            get;
        }

        private IHostEnvironment Environment
        {
            get;
        }

        private IHostApplicationLifetime ApplicationLifetime
        {
            get;
        }

        private HostOptions HostOptions
        {
            get;
        }

        private ILogger Logger
        {
            get;
        }

        public WpfLifetime(IOptions<ConsoleLifetimeOptions> options, IHostEnvironment environment, IHostApplicationLifetime applicationLifetime, IOptions<HostOptions> hostOptions)
            : this(options, environment, applicationLifetime, hostOptions, NullLoggerFactory.Instance)
        {
        }

        public WpfLifetime(IOptions<ConsoleLifetimeOptions> options, IHostEnvironment environment, IHostApplicationLifetime applicationLifetime, IOptions<HostOptions> hostOptions, ILoggerFactory loggerFactory)
        {
            Options = (options?.Value ?? throw new ArgumentNullException("options"));
            Environment = (environment ?? throw new ArgumentNullException("environment"));
            ApplicationLifetime = (applicationLifetime ?? throw new ArgumentNullException("applicationLifetime"));
            HostOptions = (hostOptions?.Value ?? throw new ArgumentNullException("hostOptions"));
            Logger = loggerFactory.CreateLogger("Microsoft.Hosting.Lifetime");
        }

        public Task WaitForStartAsync(CancellationToken cancellationToken)
        {
            if (!Options.SuppressStatusMessages)
            {
                _applicationStartedRegistration = ApplicationLifetime.ApplicationStarted.Register(delegate (object state)
                {
                    ((WpfLifetime)state).OnApplicationStarted();
                }, this);
                _applicationStoppingRegistration = ApplicationLifetime.ApplicationStopping.Register(delegate (object state)
                {
                    ((WpfLifetime)state).OnApplicationStopping();
                }, this);
            }
            //AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);
            //Console.CancelKeyPress += new ConsoleCancelEventHandler(OnCancelKeyPress);
            return Task.CompletedTask;
        }

        private void OnApplicationStarted()
        {
            Logger.LogInformation("Application started. Press Ctrl+C to shut down.");
            Logger.LogInformation("Hosting environment: {envName}", Environment.EnvironmentName);
            Logger.LogInformation("Content root path: {contentRoot}", Environment.ContentRootPath);
        }

        private void OnApplicationStopping()
        {
            Logger.LogInformation("Application is shutting down...");
        }

        private void OnProcessExit(object sender, EventArgs e)
        {
            ApplicationLifetime.StopApplication();
            if (!_shutdownBlock.WaitOne(HostOptions.ShutdownTimeout))
            {
                Logger.LogInformation("Waiting for the host to be disposed. Ensure all 'IHost' instances are wrapped in 'using' blocks.");
            }
            _shutdownBlock.WaitOne();
            System.Environment.ExitCode = 0;
        }

        private void OnCancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            e.Cancel = true;
            ApplicationLifetime.StopApplication();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            //_shutdownBlock.Set();
            //AppDomain.CurrentDomain.ProcessExit -= new EventHandler(OnProcessExit);
            //Console.CancelKeyPress -= new ConsoleCancelEventHandler(OnCancelKeyPress);
            _applicationStartedRegistration.Dispose();
            _applicationStoppingRegistration.Dispose();
        }
    }
}
