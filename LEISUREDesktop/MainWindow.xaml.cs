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
using LEISURECore;

namespace LEISUREDesktop
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Objects_Click(object sender, RoutedEventArgs e)
        {
            Windows.Objects objects = new Windows.Objects();
            objects.Show();
            this.Close();
        }

        private void New_Object_Click(object sender, RoutedEventArgs e)
        {
            Windows.NewObject newObject = new Windows.NewObject();
            newObject.Show();
            this.Close();
        }

        private void Events_Click(object sender, RoutedEventArgs e)
        {
            DataAccess.Refreshing();
            Windows.Visit_Event events = new Windows.Visit_Event();
            events.Show();
            this.Close();
        }

        private void New_Request_Btn_Click(object sender, RoutedEventArgs e)
        {
            Windows.NewRequest newRequest = new Windows.NewRequest();
            newRequest.Show();
            this.Close();
        }

        private void Requests_Btn_Click(object sender, RoutedEventArgs e)
        {
            Windows.Requests requests = new Windows.Requests();
            requests.Show();
            this.Close();
        }

       
    }
}
