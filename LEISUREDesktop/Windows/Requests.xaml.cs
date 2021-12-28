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
using System.Windows.Shapes;
using LEISURECore;

namespace LEISUREDesktop.Windows
{
    /// <summary>
    /// Логика взаимодействия для Requests.xaml
    /// </summary>
    public partial class Requests : Window
    {
        public List<LEISURECore.Request> requests { get; set; }
        public Requests()
        {
            InitializeComponent();
            requests = DataAccess.GetRequests();
            this.DataContext = this;
        }

        private void Accept_Request_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Nullable<int> ID_obj = (ListRequests.SelectedItem as LEISURECore.Request).ID_Object;
                Nullable<DateTime> start = (ListRequests.SelectedItem as LEISURECore.Request).Date_Start;
                Nullable<DateTime> end = (ListRequests.SelectedItem as LEISURECore.Request).Date_End;
                ;
                Nullable<int> ID_type = (ListRequests.SelectedItem as LEISURECore.Request).ID_Type_Event;
                string name = (ListRequests.SelectedItem as LEISURECore.Request).Name;
                if (DataAccess.AddNewEvent(ID_obj,name,ID_type,start, end))
                {
                    MessageBox.Show("Заявка принята!");
                }
            }

            catch
            {
                MessageBox.Show("Упс... Что-то пошло не так");
            }
        }

        private void QuitClick(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void ListRequests_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
