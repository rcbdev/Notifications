using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ExampleApplication
{
    /// <summary>
    /// Interaction logic for NotificationToast.xaml
    /// </summary>
    public partial class NotificationToast : Window
    {
        private readonly string _url;

        public NotificationToast(string message, string title, string type = "info", string url = "")
        {
            InitializeComponent();

            NotificationText.Text = message;
            NotificationHeader.Text = title;
            _url = url;

            var brConv = new BrushConverter();

            switch (type)
            {
                case "info":
                    NotificationArea.Background = (Brush)brConv.ConvertFromString("#ff2f96b4");
                    break;
                case "success":
                    NotificationArea.Background = (Brush)brConv.ConvertFromString("#ff51a351");
                    break;
                case "warning":
                    NotificationArea.Background = (Brush)brConv.ConvertFromString("#fff89406");
                    break;
                case "error":
                    NotificationArea.Background = (Brush)brConv.ConvertFromString("#ffbd362f");
                    break;
                default:
                    NotificationArea.Background = (Brush)brConv.ConvertFromString("#ff51a351");
                    break;
            }

            Dispatcher.BeginInvoke(DispatcherPriority.ApplicationIdle, new Action(() =>
            {
                var workingArea = System.Windows.SystemParameters.WorkArea;

                this.Left = workingArea.Right - this.ActualWidth;
                this.Top = workingArea.Top + 50;
                this.Topmost = true;
            }));

            this.MouseLeftButtonUp += NotificationToast_MouseLeftButtonUp;
        }

        void NotificationToast_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (!string.IsNullOrEmpty(_url))
            {
                Process.Start(_url);
            }
            this.Close();
        }

        private void Storyboard_Completed(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
