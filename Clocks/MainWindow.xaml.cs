using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
namespace Clocks
{
    public partial class MainWindow : Window
    {
        System.Timers.Timer seconds = new System.Timers.Timer();
        internal bool wink;
        public MainWindow()
        {
            InitializeComponent();
            seconds.Interval = 1000;
            seconds.Elapsed += SetTime;
            seconds.AutoReset = true;
            seconds.Enabled = true;
            wink = false;
        }
        private void SetTime(Object? source, System.Timers.ElapsedEventArgs e)
        {
            if (DateTime.Now.Hour.ToString().Length == 1)
            {
                Dispatcher.Invoke(() => Hours.Text = "0" + DateTime.Now.Hour.ToString());
            }
            else
            {
                Dispatcher.Invoke(() => Hours.Text = DateTime.Now.Hour.ToString());
            }
            if (DateTime.Now.Minute.ToString().Length == 1)
            {
                Dispatcher.Invoke(() => Minutes.Text = "0" + DateTime.Now.Minute.ToString());
            }
            else
            {
                Dispatcher.Invoke(() => Minutes.Text = DateTime.Now.Minute.ToString());
            }
            Dispatcher.Invoke(() => Colon.Text = ":");
            wink = !wink;
            int state;
            switch (wink)
            {
                case true:
                    state = 1;
                    break;
                case false:
                    state = 0;
                    break;
            }
            Dispatcher.Invoke(() => Colon.Opacity = state);
        }
        private void Window_MouseDrag(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}

