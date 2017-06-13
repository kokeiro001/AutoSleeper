using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AutoSleeper.App
{
    public partial class NotifyIconWrapper : Component
    {
          
        public NotifyIconWrapper()
        {
            InitializeComponent();
            toolStripMenuItem_Open.Click += ToolStripMenuItem_Open_Click;
            toolStripMenuItem_Exit.Click += ToolStripMenuItem_Exit_Click;
        }

        public NotifyIconWrapper(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

        }

        private void ToolStripMenuItem_Open_Click(object sender, EventArgs e)
        {
            var window = new MainWindow();
            window.Show();
        }

        private void ToolStripMenuItem_Exit_Click(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        public void ShowBalloonTip(int timeoutMilliSec, string tipTitle, string tipText)
        {
            notifyIcon.ShowBalloonTip(timeoutMilliSec, tipTitle, tipText, System.Windows.Forms.ToolTipIcon.Info);
        }
    }
}
