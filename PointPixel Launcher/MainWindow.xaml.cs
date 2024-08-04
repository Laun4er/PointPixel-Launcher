using System.Windows;
using PP_lib;

namespace PointPixel_Launcher
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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
                    break;
                case WindowState.Normal:
                    this.WindowState = WindowState.Maximized;
                    break;
            }
        }

        private void closeButton_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Border_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if(e.ClickCount == 2)
            {
                switch (this.WindowState)
                {
                    case WindowState.Maximized:
                        this.WindowState = WindowState.Normal;
                        break;
                    case WindowState.Normal:
                        this.WindowState = WindowState.Maximized;
                        break;
                }
            }
        }
    }
}