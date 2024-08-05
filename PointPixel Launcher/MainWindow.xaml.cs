using PointPixel_Launcher.Pages;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PointPixel_Launcher
{
    public partial class MainWindow : Window
    {
        private Dictionary<string, Page> pages = new Dictionary<string, Page>();
        public MainWindow()
        {
            InitializeComponent();
            
            pages.Add("Main", new Main());
            pages.Add("News", new News());
            pages.Add("Mods", new Mods());
            pages.Add("Profile", new Profile());
            pages.Add("Parametres", new Parametres());

            PageFrame.Content = pages["Main"];

            ListBox1.SelectedIndex = 0;
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
            if (e.ClickCount == 2)
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
        private IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(depObj: child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        private bool isInitialSelection = true;
        private void PageChanged(object sender, SelectionChangedEventArgs e)
        {
            if (isInitialSelection)
            {
                isInitialSelection = false;
                return;
            }

            if (sender is ListBox listBox)
            {
                if (listBox.SelectedItem is ListBoxItem selectedListBoxItem)
                {
                    switch (listBox.Name)
                    {
                        case "ListBox1":
                            ListBox2.SelectedIndex = -1;
                            break;
                        case "ListBox2":
                            ListBox1.SelectedIndex = -1;
                            break;
                    }
                    Page pageInstance = pages[selectedListBoxItem.Name];
                    PageFrame.Content = pageInstance;
                    foreach (var tabControl in FindVisualChildren<TabControl>(pageInstance))
                    {
                        tabControl.SelectedIndex = 0;
                    }
                }
            }
        }
    }
}