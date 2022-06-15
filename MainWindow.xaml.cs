using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using HOYA_IOT.ApplicationConfig;

namespace HOYA_IOT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Setting_btn_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var button = sender as Button;
            if (button != null) 
            {
                button.ContextMenu.IsOpen = true;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            StoreDataProcess.SetOK();
        }
    }
}
