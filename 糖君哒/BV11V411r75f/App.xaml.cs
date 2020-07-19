using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace BV11V411r75f
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IHost _host;
        public App()
        {
            //Startup += OnStartup;
            //Exit += OnExit;
        }

        private async void OnStartup(object sender, StartupEventArgs e)
        {
            _host = Host.CreateDefaultBuilder(e.Args)
            //_host = Host.HostProgram.CreateHostBuilder(e.Args) //这个HostProgram是另外一个项目，也就是asp.net core的项目,我新建了一个asp.net core项目，把模板自动生成的Program改成HostProgram，然后wpf项目直接调那个静态方法生成HostBuilder
                .ConfigureServices(services =>
                {
                    services.AddHostedService<ApplicationHostService>();
                    services.AddSingleton<IHostLifetime, WpfLifetime>();
                    services.AddSingleton<MainWindow>();
                })
                .Build();
            await _host.StartAsync();
        }

        private async void OnExit(object sender, ExitEventArgs e)
        {
            await _host.StopAsync();
            _host.Dispose();
            _host = null;
        }
    }
}
