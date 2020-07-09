using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace M3U8_Downloader
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            DispatcherUnhandledException += App_DispatcherUnhandledException;//针对程序中所有未处理的异常进行处理
        }

        private void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            //throw new NotImplementedException();
            MessageBox.Show("DispatcherUnhandledException 异常已处理！");
            //异常记入日志
            //调用异常处理
            e.Handled = true; //此异常已处理
            //程序重新启动
        }
    }
}
