using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using PP_lib;

namespace PointPixel_Launcher
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_StateChanged(object sender, EventArgs e)//Анимация
        {
            
        }

        private void Border_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void minimizeButton_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void maximizeBox_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            switch (this.WindowState)
            {
                case WindowState.Maximized:
                    this.WindowState = WindowState.Normal;
                    Mainwin.Width = 35;
                    var anim = new DoubleAnimation(35, (Duration)TimeSpan.FromSeconds(0.3));
                    anim.Completed += (s, _) => Expanded = false;
                    LeftNavPanel.BeginAnimation(ContentControl.WidthProperty, anim);
                    break;
                case WindowState.Normal:
                    this.WindowState = WindowState.Maximized;
                    Mainwin.Width = 205;
                    var anim1 = new DoubleAnimation(205, (Duration)TimeSpan.FromSeconds(0.3));
                    anim1.Completed += (s, _) => Expanded = false;
                    LeftNavPanel.BeginAnimation(ContentControl.WidthProperty, anim1);
                    break;
            }
        }

        private void closeButton_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.Close();
        }
        private bool Expanded = false;
        private void Border_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            

            if (e.ClickCount == 2)
            {
                switch (this.WindowState)
                {
                    case WindowState.Maximized:
                        this.WindowState = WindowState.Normal;
                        var anim = new DoubleAnimation(35, (Duration)TimeSpan.FromSeconds(0.3));
                        anim.Completed += (s, _) => Expanded = false;
                        LeftNavPanel.BeginAnimation(ContentControl.WidthProperty, anim);
                        break;
                    case WindowState.Normal:
                        this.WindowState = WindowState.Maximized;
                        var anim1 = new DoubleAnimation(205, (Duration)TimeSpan.FromSeconds(0.3));
                        anim1.Completed += (s, _) => Expanded = false;
                        LeftNavPanel.BeginAnimation(ContentControl.WidthProperty, anim1);
                        break;
                }
            }
        }
    }
}