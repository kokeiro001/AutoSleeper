using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace AutoSleeper.App
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : Application
    {
        NotifyIconWrapper notifyIcon;

        DispatcherTimer timer;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ShutdownMode = ShutdownMode.OnExplicitShutdown;
            notifyIcon = new NotifyIconWrapper();
            timer = new DispatcherTimer(DispatcherPriority.Normal);

            timer.Interval = TimeSpan.FromMinutes(0.5);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            notifyIcon.Dispose();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            var now = DateTime.Now;
            if (now.Hour == 23 && now.Minute == 50)
            {
                // あと10分後にスリープするぞと警告ポップアップ
                PopupSleepWarning();
            }
            else if (now.Hour == 0 && now.Minute == 0)
            {
                // スリープする
                SleepPC();
            }
            else
            {
                PopupSleepWarning();
            }
        }

        private void PopupSleepWarning()
        {
            notifyIcon.ShowBalloonTip(20 * 1000, "スリープするぞー", "24時になったら強制的にスリープしまーす");
        }

        private void SleepPC()
        {
            System.Windows.Forms.Application.SetSuspendState(System.Windows.Forms.PowerState.Suspend, false, false);
        }

    }
}
